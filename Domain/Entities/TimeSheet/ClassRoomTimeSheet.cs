namespace Domain.Entities.TimeSheet
{
    public class ClassRoomTimeSheet : BaseEntity
    {
        public int NumberOfStudent {  get; set; }
        public Guid? ClassRoomId { get; set; }
        public ClassRoom? ClassRoom { get; set; }

        public Guid? TimeSheetId { get; set; }
        public TimeSheet? TimeSheet { get; set; }
    }
}
