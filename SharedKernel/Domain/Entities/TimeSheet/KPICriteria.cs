using Domain.Entities;

namespace Domain.Entities.TimeSheet
{
    public class KPICriteria : BaseEntity
    {
        public string Criteria { get; set; } = string.Empty;

        public string Point { get; set; } = string.Empty;

        public string Type { get; set; } = "plus"; // "plus" or "minus"

        public int DisplayOrder { get; set; } = 0;
    }
}
