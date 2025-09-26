using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeSheetManagement.DTO;

namespace TimeSheetManagement.Queries.GetListTimesheet
{
    public class GetListTimesheetQueryHandler : IRequestHandler<GetListTimesheetQuery, GetListTimesheetQueryResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetListTimesheetQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetListTimesheetQueryResult> Handle(GetListTimesheetQuery request, CancellationToken cancellationToken)
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
                                t.tr.ts.Date,
                                t.tr.r.NumberOfStudent,
                                Level = t.cls.Level,
                                ClassCode = t.cls.ClassCode,
                                Reviews = revs.Select(r => new TimesheetReviewDTO
                                {
                                    StudentId = r.StudentId,
                                    Name = r.Student != null ? r.Student.Name : string.Empty,
                                    Review = r.Review,
                                    Progress = r.Progress
                                }).ToList()
                            })
                 .ToListAsync();

            var salaries = await _unitOfWork.Salaries.GetListByConditionAsync(s => s.IsActive);

            // Parse month and year from request
            string reqMonth = request.Month;
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
            // If both are null/empty, do not filter: return all timesheets

            // ... previous code ...

            var maxStudentByLevel = salaries
                .GroupBy(s => s.Level)
                .ToDictionary(
                    g => g.Key,
                    g => g.Max(s => s.NumberOfStudent)
                );

            var result = timesheets
                .Select(t =>
                {
                    // Find all salary records for this level
                    var salaryList = salaries.Where(s => s.Level == t.Level).ToList();
                    decimal amount = 0;

                    if (salaryList.Count > 0)
                    {
                        int maxStudent = maxStudentByLevel[t.Level];
                        if (t.NumberOfStudent >= maxStudent)
                        {
                            // Use the max salary for this level
                            amount = salaryList
                                .Where(s => s.NumberOfStudent == maxStudent)
                                .Select(s => s.Money)
                                .FirstOrDefault();
                        }
                        else
                        {
                            // Use the salary for the exact number of students
                            amount = salaryList
                                .Where(s => s.NumberOfStudent == t.NumberOfStudent)
                                .Select(s => s.Money)
                                .FirstOrDefault();
                        }
                    }

                    var allowance = t.ClassCode.StartsWith("VLB") ? 50000 : 0;
                    return new TimeSheetDTO
                    {
                        Classcode = t.ClassCode,
                        Date = t.Date,
                        NumberOfStudent = t.NumberOfStudent,
                        Level = t.Level,
                        Salary = amount,
                        Allowance = allowance,
                        TotalSalary = amount + allowance,
                        Reviews = t.Reviews
                    };
                })
                .OrderByDescending(x => x.Date);

            var groupedResult = result
                .GroupBy(ts => new
                {
                    Year = ts.Date.Year,
                    Month = ts.Date.ToString("MMM yyyy")
                })
                .Select(g => new TimesheetResult
                {
                    Month = g.Key.Month,
                    TimeSheet = g.ToList(),
                    AllowanceTotal = g.Sum(x => x.Allowance),
                    GrossTotal = g.Sum(x => x.TotalSalary),
                    TaxforCharity = g.Sum(x => x.Salary) * 2/100,
                    NetTotal = g.Sum(x => x.TotalSalary) - (g.Sum(x => x.Salary) * 2 / 100)
                })
                .ToList();

            return new GetListTimesheetQueryResult
            {
                Results = groupedResult,
            };
        }
    }
}
