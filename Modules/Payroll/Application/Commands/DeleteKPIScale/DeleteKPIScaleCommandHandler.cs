using Domain.Repositories;
using MediatR;

namespace TimeSheetManagement.Commands.DeleteKPIScale
{
    public class DeleteKPIScaleCommandHandler : IRequestHandler<DeleteKPIScaleCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteKPIScaleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteKPIScaleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.KPIScales.GetByIdAsync(request.Id);
            if (entity == null) return false;

            await _unitOfWork.KPIScales.DeleteAsync(request.Id);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
