using Domain.Repositories;
using MediatR;

namespace TimeSheetManagement.Commands.DeleteStudent
{
    public class DeleteStudentByIdCommandHandler : IRequestHandler<DeleteStudentByIdCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteStudentByIdCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteStudentByIdCommand request, CancellationToken cancellationToken)
        {
            var student = await _unitOfWork.Students.GetOne(x => x.IsActive && x.Id == request.Id);
            if (student == null)
            {
                return false;
            }

            student.IsActive = false;
            student.UpdatedDate = DateTime.UtcNow;
            await _unitOfWork.Students.UpdateAsync(student);

            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
