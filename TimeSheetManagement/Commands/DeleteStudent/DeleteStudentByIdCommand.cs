using MediatR;

namespace TimeSheetManagement.Commands.DeleteStudent
{
    public class DeleteStudentByIdCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}

