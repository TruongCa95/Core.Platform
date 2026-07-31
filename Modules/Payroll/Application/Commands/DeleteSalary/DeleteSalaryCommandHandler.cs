using Domain.Repositories;
using MediatR;

namespace TimeSheetManagement.Commands.DeleteSalary
{
    public class DeleteSalaryCommandHandler : IRequestHandler<DeleteSalaryCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSalaryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteSalaryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Salaries.GetByIdAsync(request.Id);
            if (entity == null) return false;

            await _unitOfWork.Salaries.DeleteAsync(request.Id);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
