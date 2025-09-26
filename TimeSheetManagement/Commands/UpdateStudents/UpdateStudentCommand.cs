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
    }
}
