using Domain.Enums;
using MediatR;

namespace TimeSheetManagement.Commands.UpsertTeacherClassMonthlyKPI
{
    public class UpsertTeacherClassMonthlyKPICommand : IRequest<Guid>
    {
        public Guid ClassroomId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public KiEnums KPI { get; set; }
        public string Note { get; set; } = string.Empty;
    }
}
