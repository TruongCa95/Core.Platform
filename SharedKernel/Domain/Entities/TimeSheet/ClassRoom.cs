using Domain.Entities;
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

        public ClassRoomStatusEnums Status { get; set; } = ClassRoomStatusEnums.Active;

        public decimal Allowance { get; set; } = 0;
    }
}
