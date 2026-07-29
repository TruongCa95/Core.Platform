using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeSheetManagement.DTO;
using TimeSheetManagement.Services;

namespace TimeSheetManagement.Queries.GetListTeacherClassMonthlyKPI
{
    public class GetListTeacherClassMonthlyKPIQueryHandler : IRequestHandler<GetListTeacherClassMonthlyKPIQuery, List<TeacherClassMonthlyKPIDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICalculationSalaryService _calculationSalaryService;

        public GetListTeacherClassMonthlyKPIQueryHandler(IUnitOfWork unitOfWork, ICalculationSalaryService calculationSalaryService)
        {
            _unitOfWork = unitOfWork;
            _calculationSalaryService = calculationSalaryService;
        }

        public async Task<List<TeacherClassMonthlyKPIDTO>> Handle(GetListTeacherClassMonthlyKPIQuery request, CancellationToken cancellationToken)
        {
            var query = _unitOfWork.TeacherClassMonthlyKPIs.GetAll()
                .Include(x => x.ClassRoom)
                .Where(x => x.IsActive);

            if (request.ClassroomId.HasValue && request.ClassroomId.Value != Guid.Empty)
            {
                query = query.Where(x => x.ClassroomId == request.ClassroomId.Value);
            }
            if (request.Year.HasValue)
            {
                query = query.Where(x => x.Year == request.Year.Value);
            }
            if (request.Month.HasValue)
            {
                query = query.Where(x => x.Month == request.Month.Value);
            }

            var list = await query.ToListAsync(cancellationToken);

            return list.Select(k => new TeacherClassMonthlyKPIDTO
            {
                Id = k.Id,
                ClassroomId = k.ClassroomId,
                ClassCode = k.ClassRoom?.ClassCode ?? string.Empty,
                ClassName = k.ClassRoom?.ClassName ?? string.Empty,
                Year = k.Year,
                Month = k.Month,
                KPI = k.KPI,
                KPIFactor = _calculationSalaryService.CalculateKi(k.KPI),
                Note = k.Note ?? string.Empty
            }).ToList();
        }
    }
}
