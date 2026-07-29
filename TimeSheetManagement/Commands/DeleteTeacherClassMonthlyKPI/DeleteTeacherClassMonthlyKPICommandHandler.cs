using Domain.Repositories;
using MediatR;

namespace TimeSheetManagement.Commands.DeleteTeacherClassMonthlyKPI
{
    public class DeleteTeacherClassMonthlyKPICommandHandler : IRequestHandler<DeleteTeacherClassMonthlyKPICommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTeacherClassMonthlyKPICommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteTeacherClassMonthlyKPICommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.TeacherClassMonthlyKPIs.GetByIdAsync(request.Id);
            if (entity == null) return false;

            await _unitOfWork.TeacherClassMonthlyKPIs.DeleteAsync(request.Id);
            var count = await _unitOfWork.CompleteAsync();
            return count > 0;
        }
    }
}
