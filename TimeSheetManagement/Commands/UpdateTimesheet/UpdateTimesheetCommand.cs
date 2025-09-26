using MediatR;

namespace TimeSheetManagement.Commands.UpdateTimesheet
{
    public class UpdateTimesheetCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public DateTime Date {  get; set; }


    }
}
