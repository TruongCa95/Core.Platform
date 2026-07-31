using Domain.Enums;

namespace TimeSheetManagement.DTO
{
    public class CalculationSalaryRequest
    {
        public Guid ClassroomId { get; set; }

        public LevelEnums level { get; set; }

        public LocationEnums location { get; set; }

        public int numberOfStudent { get; set; }

        public KiEnums ki { get; set; }
    }
}
