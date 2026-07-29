using MediatR;

namespace TimeSheetManagement.Commands.DeleteKPIScale
{
    public class DeleteKPIScaleCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteKPIScaleCommand(Guid id)
        {
            Id = id;
        }
    }
}
