namespace TimeSheetManagement.DTO
{
    public class KPICriteriaDTO
    {
        public Guid Id { get; set; }
        public string Criteria { get; set; } = string.Empty;
        public string Point { get; set; } = string.Empty;
        public string Type { get; set; } = "plus";
        public int DisplayOrder { get; set; }
    }
}
