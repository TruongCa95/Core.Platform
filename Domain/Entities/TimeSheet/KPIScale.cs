namespace Domain.Entities.TimeSheet
{
    public class KPIScale : BaseEntity
    {
        public string Grade { get; set; } = string.Empty; // e.g. "Ki A*", "Ki A"

        public string Score { get; set; } = string.Empty; // e.g. "140đ", "125đ"

        public decimal Factor { get; set; } = 1.0m; // e.g. 1.4, 1.25

        public string Description { get; set; } = string.Empty;

        public int DisplayOrder { get; set; } = 0;
    }
}
