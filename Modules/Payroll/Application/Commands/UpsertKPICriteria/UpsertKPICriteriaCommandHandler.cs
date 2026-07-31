using Domain.Entities.TimeSheet;
using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace TimeSheetManagement.Commands.UpsertKPICriteria
{
    public class UpsertKPICriteriaCommandHandler : IRequestHandler<UpsertKPICriteriaCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertKPICriteriaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(UpsertKPICriteriaCommand request, CancellationToken cancellationToken)
        {
            if (request.Id.HasValue && request.Id.Value != Guid.Empty)
            {
                var existing = await _unitOfWork.KPICriterias.GetByIdAsync(request.Id.Value);
                if (existing != null)
                {
                    existing.Criteria = request.Criteria;
                    existing.Point = request.Point;
                    existing.Type = request.Type;
                    existing.DisplayOrder = request.DisplayOrder;
                    existing.UpdatedDate = DateTime.UtcNow;

                    await _unitOfWork.KPICriterias.UpdateAsync(existing);
                    await _unitOfWork.CompleteAsync();
                    return existing.Id;
                }
            }

            var entity = new KPICriteria
            {
                Id = Guid.NewGuid(),
                Criteria = request.Criteria,
                Point = request.Point,
                Type = request.Type,
                DisplayOrder = request.DisplayOrder,
                IsActive = true,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            await _unitOfWork.KPICriterias.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
            return entity.Id;
        }
    }
}
