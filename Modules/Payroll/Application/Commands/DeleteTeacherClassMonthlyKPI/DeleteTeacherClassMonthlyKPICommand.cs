using MediatR;

namespace TimeSheetManagement.Commands.DeleteTeacherClassMonthlyKPI
{
    public class DeleteTeacherClassMonthlyKPICommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
