using MediatR;

namespace TimeSheetManagement.Commands.UpsertKPICriteria
{
    public class UpsertKPICriteriaCommand : IRequest<Guid>
    {
        public Guid? Id { get; set; }
        public string Criteria { get; set; } = string.Empty;
        public string Point { get; set; } = string.Empty;
        public string Type { get; set; } = "plus";
        public int DisplayOrder { get; set; }
    }
}
