namespace TimeSheetManagement.DTO
{
    public class KPIScaleDTO
    {
        public Guid Id { get; set; }
        public string Grade { get; set; } = string.Empty;
        public string Score { get; set; } = string.Empty;
        public decimal Factor { get; set; }
        public string Description { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
    }
}
