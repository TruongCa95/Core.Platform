using Domain.Enums;
using MediatR;

namespace TimeSheetManagement.Commands.UpdateStudents
{
    public class UpdateStudentCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Grade { get; set; }

        public string? Review { get; set; }

        // Optional: when provided (even empty), the student's classroom enrolments are
        // reconciled to exactly match this list. When null, enrolments are left untouched.
        public List<Guid>? ClassroomIds { get; set; }
    }
}
