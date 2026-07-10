using Domain.Entities.TimeSheet;
using Domain.Repositories;
using MediatR;

namespace TimeSheetManagement.Commands.UpdateStudents
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateStudentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _unitOfWork.Students.GetOne(x => x.IsActive && x.Id == request.Id);
            if (student == null)
            {
                return false;
            }

            student.Name = request.Name ?? string.Empty;
            student.Grade = request.Grade ?? string.Empty;
            student.Review = request.Review ?? string.Empty;
            student.UpdatedDate = DateTime.UtcNow;
            await _unitOfWork.Students.UpdateAsync(student);

            // Reconcile classroom enrolments only when the caller sends the list.
            if (request.ClassroomIds != null)
            {
                await ReconcileEnrolments(student.Id, request.ClassroomIds);
            }

            await _unitOfWork.CompleteAsync();
            return true;
        }

        private async Task ReconcileEnrolments(Guid studentId, List<Guid> desiredClassIds)
        {
            var desired = desiredClassIds.Distinct().ToList();

            // Load every enrolment row (active or not) so we can reactivate soft-deleted ones
            // instead of creating duplicates.
            var existing = await _unitOfWork.StudentClasses
                .GetListByConditionAsync(x => x.StudentId == studentId);

            foreach (var enrolment in existing)
            {
                var shouldBeActive = desired.Contains(enrolment.ClassId);
                if (enrolment.IsActive != shouldBeActive)
                {
                    enrolment.IsActive = shouldBeActive;
                    enrolment.UpdatedDate = DateTime.UtcNow;
                    await _unitOfWork.StudentClasses.UpdateAsync(enrolment);
                }
            }

            var existingClassIds = existing.Select(x => x.ClassId).ToHashSet();
            var toAdd = desired
                .Where(classId => !existingClassIds.Contains(classId))
                .Select(classId => new StudentClasses
                {
                    StudentId = studentId,
                    ClassId = classId
                })
                .ToList();

            if (toAdd.Count > 0)
            {
                await _unitOfWork.StudentClasses.AddRangeAsync(toAdd);
            }
        }
    }
}
