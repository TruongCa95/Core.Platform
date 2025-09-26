namespace Domain.Entities.TimeSheet
{
    public class StudentClasses : BaseEntity
    {
        public Guid StudentId { get; set; }

        public Guid ClassId { get; set; }

        public Students? Students { get; set; }

        public ClassRoom? ClassRoom { get; set; }
    }
}
