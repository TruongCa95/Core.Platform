using Domain.Repositories;
using MediatR;

namespace TimeSheetManagement.Commands.DeleteKPICriteria
{
    public class DeleteKPICriteriaCommandHandler : IRequestHandler<DeleteKPICriteriaCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteKPICriteriaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteKPICriteriaCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.KPICriterias.GetByIdAsync(request.Id);
            if (entity == null) return false;

            await _unitOfWork.KPICriterias.DeleteAsync(request.Id);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
