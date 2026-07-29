using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeSheetManagement.DTO;

namespace TimeSheetManagement.Queries.GetListKPIScale
{
    public class GetListKPIScaleQueryHandler : IRequestHandler<GetListKPIScaleQuery, List<KPIScaleDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetListKPIScaleQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<KPIScaleDTO>> Handle(GetListKPIScaleQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.KPIScales.GetAll()
                .Where(x => x.IsActive)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync(cancellationToken);

            return list.Select(x => new KPIScaleDTO
            {
                Id = x.Id,
                Grade = x.Grade,
                Score = x.Score,
                Factor = x.Factor,
                Description = x.Description,
                DisplayOrder = x.DisplayOrder
            }).ToList();
        }
    }
}
