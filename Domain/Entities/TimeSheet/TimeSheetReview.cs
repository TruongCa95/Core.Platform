namespace Domain.Entities.TimeSheet
{
    public class TimesheetReview : BaseEntity
    {
        public Guid StudentId { get; set; }

        public Students? Student { get; set; } 

        public Guid TimesheetId { get; set; }

        public TimeSheet? TimeSheet { get; set; }

        public string Review {  get; set; } = string.Empty;

        public decimal? Progress { get; set; }
    }
}
