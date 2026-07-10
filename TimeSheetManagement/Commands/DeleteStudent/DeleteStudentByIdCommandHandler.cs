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

            // Soft-delete the student's classroom enrolments so they are no longer
            // counted or joined once the student is gone.
            var enrolments = await _unitOfWork.StudentClasses
                .GetListByConditionAsync(x => x.IsActive && x.StudentId == request.Id);
            foreach (var enrolment in enrolments)
            {
                enrolment.IsActive = false;
                enrolment.UpdatedDate = DateTime.UtcNow;
                await _unitOfWork.StudentClasses.UpdateAsync(enrolment);
            }

            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
