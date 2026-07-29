using Domain.Entities.TimeSheet;
using Domain.Repositories;
using MediatR;

namespace TimeSheetManagement.Commands.UpsertKPIScale
{
    public class UpsertKPIScaleCommandHandler : IRequestHandler<UpsertKPIScaleCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertKPIScaleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(UpsertKPIScaleCommand request, CancellationToken cancellationToken)
        {
            if (request.Id.HasValue && request.Id.Value != Guid.Empty)
            {
                var existing = await _unitOfWork.KPIScales.GetByIdAsync(request.Id.Value);
                if (existing != null)
                {
                    existing.Grade = request.Grade;
                    existing.Score = request.Score;
                    existing.Factor = request.Factor;
                    existing.Description = request.Description;
                    existing.DisplayOrder = request.DisplayOrder;
                    existing.UpdatedDate = DateTime.UtcNow;

                    await _unitOfWork.KPIScales.UpdateAsync(existing);
                    await _unitOfWork.CompleteAsync();
                    return existing.Id;
                }
            }

            var entity = new KPIScale
            {
                Id = Guid.NewGuid(),
                Grade = request.Grade,
                Score = request.Score,
                Factor = request.Factor,
                Description = request.Description,
                DisplayOrder = request.DisplayOrder,
                IsActive = true,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            await _unitOfWork.KPIScales.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
            return entity.Id;
        }
    }
}
