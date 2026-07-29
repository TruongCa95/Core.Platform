using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeSheetManagement.DTO;

namespace TimeSheetManagement.Queries.GetListKPICriteria
{
    public class GetListKPICriteriaQueryHandler : IRequestHandler<GetListKPICriteriaQuery, List<KPICriteriaDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetListKPICriteriaQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<KPICriteriaDTO>> Handle(GetListKPICriteriaQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.KPICriterias.GetAll()
                .Where(x => x.IsActive)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync(cancellationToken);

            return list.Select(x => new KPICriteriaDTO
            {
                Id = x.Id,
                Criteria = x.Criteria,
                Point = x.Point,
                Type = x.Type,
                DisplayOrder = x.DisplayOrder
            }).ToList();
        }
    }
}
