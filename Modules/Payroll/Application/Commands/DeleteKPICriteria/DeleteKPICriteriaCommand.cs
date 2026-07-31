using MediatR;

namespace TimeSheetManagement.Commands.DeleteKPICriteria
{
    public class DeleteKPICriteriaCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteKPICriteriaCommand(Guid id)
        {
            Id = id;
        }
    }
}
