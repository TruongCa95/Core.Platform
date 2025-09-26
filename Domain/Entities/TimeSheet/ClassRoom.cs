using Domain.Enums;

namespace Domain.Entities.TimeSheet
{
    public class ClassRoom : BaseEntity
    {
        public string ClassCode { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public string ClassName { get; set; } = string.Empty;

        public int NumberOfStudent { get; set; } = 1;

        public LevelEnums Level { get; set; }

        public ICollection<TimeSheet> TimeSheets { get; set; } = new List<TimeSheet>();

        public ICollection<Students> Students { get; set; } = new List<Students>();
    }
}
