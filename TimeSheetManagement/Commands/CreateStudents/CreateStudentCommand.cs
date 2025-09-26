using MediatR;

namespace TimeSheetManagement.Commands.CreateStudents
{
    public class CreateStudentCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;

        public string Grade { get; set; } = string.Empty;

        public string Review {  get; set; } = string.Empty;

        public List<Guid> ClassroomIds { get; set; } = new List<Guid>();
    }
}
