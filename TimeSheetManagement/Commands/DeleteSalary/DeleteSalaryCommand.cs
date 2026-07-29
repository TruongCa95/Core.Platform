using MediatR;

namespace TimeSheetManagement.Commands.DeleteSalary
{
    public class DeleteSalaryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteSalaryCommand(Guid id)
        {
            Id = id;
        }
    }
}
