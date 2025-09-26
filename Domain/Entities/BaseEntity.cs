namespace Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public bool IsActive { get; set; } = true;

        public string CreatedBy { get; set; } = string.Empty;

        public string UpdatedBy { get; set;} = string.Empty;

        public DateTime CreatedDate { get; set;} = DateTime.UtcNow;

        public DateTime UpdatedDate { get; set;} = DateTime.UtcNow;
    }
}
