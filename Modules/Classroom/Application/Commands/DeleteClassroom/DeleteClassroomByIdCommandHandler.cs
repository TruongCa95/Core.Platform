using Domain.Repositories;
using MediatR;

namespace TimeSheetManagement.Commands.DeleteClassroom
{
    public class DeleteClassroomByIdCommandHandler : IRequestHandler<DeleteClassroomByIdCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteClassroomByIdCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteClassroomByIdCommand request, CancellationToken cancellationToken)
        {
            var classroom = await _unitOfWork.Classrooms.GetOne(x => x.IsActive && x.Id == request.Id);
            if (classroom == null)
            {
                return false;
            }

            classroom.IsActive = false;
            classroom.UpdatedDate = DateTime.UtcNow;
            await _unitOfWork.Classrooms.UpdateAsync(classroom);

            // Soft-delete the enrolments that reference this classroom so students
            // are no longer linked to a class that no longer exists.
            var enrolments = await _unitOfWork.StudentClasses
                .GetListByConditionAsync(x => x.IsActive && x.ClassId == request.Id);
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
