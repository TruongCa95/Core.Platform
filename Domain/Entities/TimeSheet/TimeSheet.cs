namespace Domain.Entities.TimeSheet
{
    public class TimeSheet : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public ICollection<ClassRoom> ClassRooms { get; set; } = new List<ClassRoom>();
    }
}
