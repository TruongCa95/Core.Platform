using Newtonsoft.Json;

namespace TimeSheetManagement.DTO
{
    public class TimesheetReviewDTO
    {
        public Guid StudentId { get; set; }

        [JsonIgnore]
        public string? Name { get; set; }

        public string Review { get; set; } = string.Empty;

        public decimal? Progress { get; set; }
    }
}
