using Domain.Enums;

namespace Domain.Entities.TimeSheet
{
    public class Salary : BaseEntity
    {
        public decimal Money { get; set; }

        public LevelEnums Level { get; set; }

        public int NumberOfStudent {  get; set; }
    }
}
