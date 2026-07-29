using Domain.Entities.TimeSheet;
using Domain.Repositories;
using MediatR;

namespace TimeSheetManagement.Commands.UpsertSalary
{
    public class UpsertSalaryCommandHandler : IRequestHandler<UpsertSalaryCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertSalaryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(UpsertSalaryCommand request, CancellationToken cancellationToken)
        {
            if (request.Id.HasValue && request.Id.Value != Guid.Empty)
            {
                var existing = await _unitOfWork.Salaries.GetByIdAsync(request.Id.Value);
                if (existing != null)
                {
                    existing.Money = request.Money;
                    existing.Level = request.Level;
                    existing.NumberOfStudent = request.NumberOfStudent;
                    existing.UpdatedDate = DateTime.UtcNow;

                    await _unitOfWork.Salaries.UpdateAsync(existing);
                    await _unitOfWork.CompleteAsync();
                    return existing.Id;
                }
            }

            var entity = new Salary
            {
                Id = Guid.NewGuid(),
                Money = request.Money,
                Level = request.Level,
                NumberOfStudent = request.NumberOfStudent,
                IsActive = true,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            await _unitOfWork.Salaries.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
            return entity.Id;
        }
    }
}
