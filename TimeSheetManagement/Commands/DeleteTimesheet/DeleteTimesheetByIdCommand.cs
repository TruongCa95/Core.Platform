using MediatR;

namespace TimeSheetManagement.Commands.DeleteTimesheet
{
    public class DeleteTimesheetByIdCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
