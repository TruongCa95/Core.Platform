using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeSheetManagement.DTO;

namespace TimeSheetManagement.Queries.GetListSalary
{
    public class GetListSalaryQueryHandler : IRequestHandler<GetListSalaryQuery, List<SalaryDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetListSalaryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<SalaryDTO>> Handle(GetListSalaryQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.Salaries.GetAll()
                .OrderBy(x => x.Level)
                .ThenBy(x => x.NumberOfStudent)
                .ToListAsync(cancellationToken);

            return list.Select(x => new SalaryDTO
            {
                Id = x.Id,
                Money = x.Money,
                Level = (int)x.Level,
                NumberOfStudent = x.NumberOfStudent
            }).ToList();
        }
    }
}
