using MediatR;

namespace TimeSheetManagement.Commands.DeleteClassroom
{
    public class DeleteClassroomByIdCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
