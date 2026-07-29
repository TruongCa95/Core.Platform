using Domain.Enums;

namespace TimeSheetManagement.DTO
{
    public class TeacherClassMonthlyKPIDTO
    {
        public Guid Id { get; set; }
        public Guid ClassroomId { get; set; }
        public string ClassCode { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public int Year { get; set; }
        public int Month { get; set; }
        public KiEnums KPI { get; set; }
        public decimal KPIFactor { get; set; }
        public string Note { get; set; } = string.Empty;
    }
}
