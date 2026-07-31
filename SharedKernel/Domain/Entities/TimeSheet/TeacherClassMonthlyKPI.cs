using Domain.Entities;
using Domain.Enums;

namespace Domain.Entities.TimeSheet
{
    public class TeacherClassMonthlyKPI : BaseEntity
    {
        public Guid ClassroomId { get; set; }

        public ClassRoom? ClassRoom { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public KiEnums KPI { get; set; } = KiEnums.B;

        public string Note { get; set; } = string.Empty;
    }
}
