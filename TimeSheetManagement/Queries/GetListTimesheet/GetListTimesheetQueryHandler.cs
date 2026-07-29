using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeSheetManagement.DTO;
using TimeSheetManagement.Services;

namespace TimeSheetManagement.Queries.GetListTimesheet
{
    public class GetListTimesheetQueryHandler : IRequestHandler<GetListTimesheetQuery, PagedTimesheetResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICalculationSalaryService _calculationSalaryService;

        public GetListTimesheetQueryHandler(IUnitOfWork unitOfWork, ICalculationSalaryService calculationSalaryService)
        {
            _unitOfWork = unitOfWork;
            _calculationSalaryService = calculationSalaryService;
        }

        public async Task<PagedTimesheetResult> Handle(GetListTimesheetQuery request, CancellationToken cancellationToken)
        {
            var timesheets = await _unitOfWork.ClassRoomTimeSheets
                 .GetListByCondition(x => x.TimeSheetId.HasValue)
                 .Join(_unitOfWork.TimeSheets.GetAll(),
                       r => r.TimeSheetId ?? Guid.NewGuid(),
                       ts => ts.Id,
                       (r, ts) => new { r, ts })
                 .Join(_unitOfWork.Classrooms.GetAll(),
                       tr => tr.r.ClassRoomId,
                       cls => cls.Id,
                       (tr, cls) => new { tr, cls })
                 .GroupJoin(_unitOfWork.TimesheetReviews.GetAll(),
                            t => t.tr.ts.Id,
                            rev => rev.TimesheetId,
                            (t, revs) => new
                            {
                                TimesheetId = t.tr.ts.Id,
                                ClassroomId = t.cls.Id,
                                Description = t.tr.ts.Description,
                                t.tr.ts.Date,
                                t.tr.r.NumberOfStudent,
                                Level = t.cls.Level,
                                ClassCode = t.cls.ClassCode,
                                Allowance = t.cls.Allowance,
                                Reviews = revs.Select(r => new TimesheetReviewDTO
                                {
                                    StudentId = r.StudentId,
                                    Name = r.Student != null ? r.Student.Name : string.Empty,
                                    Review = r.Review,
                                    Progress = r.Progress
                                }).ToList()
                            })
                 .ToListAsync(cancellationToken);

            var salaries = await _unitOfWork.Salaries.GetListByConditionAsync(s => s.IsActive);
            var monthlyKpis = await _unitOfWork.TeacherClassMonthlyKPIs.GetListByConditionAsync(k => k.IsActive);

            string? reqMonth = request.Month;
            int? reqYear = request.Year;

            // Only filter if at least one is provided
            if (!string.IsNullOrEmpty(reqMonth) || reqYear.HasValue)
            {
                timesheets = timesheets.Where(t =>
                {
                    bool monthMatch = true;
                    bool yearMatch = true;

                    if (!string.IsNullOrEmpty(reqMonth))
                    {
                        monthMatch = t.Date.ToString("MMM", System.Globalization.CultureInfo.InvariantCulture)
                            .Equals(reqMonth, StringComparison.OrdinalIgnoreCase);
                    }
                    if (reqYear.HasValue)
                    {
                        yearMatch = t.Date.Year == reqYear.Value;
                    }
                    return monthMatch && yearMatch;
                }).ToList();
            }

            var maxStudentByLevel = salaries
                .GroupBy(s => s.Level)
                .ToDictionary(
                    g => g.Key,
                    g => g.Max(s => s.NumberOfStudent)
                );

            var resultList = timesheets
                .Select(t =>
                {
                    // Find all salary records for this level
                    var salaryList = salaries.Where(s => s.Level == t.Level).ToList();
                    decimal amount = 0;

                    if (salaryList.Count > 0)
                    {
                        int maxStudent = maxStudentByLevel.ContainsKey(t.Level) ? maxStudentByLevel[t.Level] : 0;
                        if (t.NumberOfStudent >= maxStudent)
                        {
                            amount = salaryList
                                .Where(s => s.NumberOfStudent == maxStudent)
                                .Select(s => s.Money)
                                .FirstOrDefault();
                        }
                        else
                        {
                            amount = salaryList
                                .Where(s => s.NumberOfStudent == t.NumberOfStudent)
                                .Select(s => s.Money)
                                .FirstOrDefault();
                        }
                    }

                    var allowance = t.Allowance;
                    return new TimeSheetDTO
                    {
                        Id = t.TimesheetId,
                        ClassroomId = t.ClassroomId,
                        Description = t.Description,
                        Classcode = t.ClassCode,
                        Date = t.Date,
                        NumberOfStudent = t.NumberOfStudent,
                        Level = (int)t.Level,
                        Salary = amount,
                        Allowance = allowance,
                        TotalSalary = amount + allowance,
                        Reviews = t.Reviews
                    };
                })
                .OrderByDescending(x => x.Date)
                .ToList();

            var groupedResult = resultList
                .GroupBy(ts => new
                {
                    Year = ts.Date.Year,
                    MonthInt = ts.Date.Month,
                    MonthStr = ts.Date.ToString("MMM yyyy")
                })
                .Select(g =>
                {
                    var year = g.Key.Year;
                    var monthInt = g.Key.MonthInt;

                    // Calculate total teaching salary with KPI factor for each class in this month
                    decimal teachingSalaryWithKPI = 0;
                    var classGroups = g.GroupBy(x => x.ClassroomId);
                    foreach (var cg in classGroups)
                    {
                        var baseClassSalarySum = cg.Sum(x => x.Salary);
                        var kpiRecord = monthlyKpis.FirstOrDefault(k => k.ClassroomId == cg.Key && k.Year == year && k.Month == monthInt);
                        var kpiFactor = kpiRecord != null ? _calculationSalaryService.CalculateKi(kpiRecord.KPI) : 1.0m;
                        teachingSalaryWithKPI += baseClassSalarySum * kpiFactor;
                    }

                    decimal allowanceTotal = g.Sum(x => x.Allowance);
                    decimal grossTotal = teachingSalaryWithKPI + allowanceTotal;
                    decimal taxforCharity = Math.Round(teachingSalaryWithKPI * 0.02m, 2);
                    decimal netTotal = grossTotal - taxforCharity;

                    return new TimesheetResult
                    {
                        Month = g.Key.MonthStr,
                        TimeSheet = g.ToList(),
                        AllowanceTotal = allowanceTotal,
                        GrossTotal = grossTotal,
                        TaxforCharity = taxforCharity,
                        NetTotal = netTotal
                    };
                })
                .ToList();

            var page = request.Page <= 0 ? 1 : request.Page;
            var pageSize = request.PageSize <= 0 ? 20 : request.PageSize;
            var totalCount = groupedResult.Count;
            var pagedResults = groupedResult.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return new PagedTimesheetResult
            {
                Results = pagedResults,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };
        }
    }
}
