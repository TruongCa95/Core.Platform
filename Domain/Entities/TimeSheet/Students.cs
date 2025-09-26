using Domain.Enums;

namespace Domain.Entities.TimeSheet
{
    public class Students : BaseEntity
    {
        public string Name { get;  set; } = string.Empty;

        public string Grade { get;  set; } = string.Empty;

        public string Review {  get;  set; } = string.Empty;

        public ICollection<ClassRoom> ClassRooms { get; private set; } = new List<ClassRoom>();

    }
}
