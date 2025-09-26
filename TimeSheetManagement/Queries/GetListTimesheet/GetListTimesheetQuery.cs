using MediatR;

namespace TimeSheetManagement.Queries.GetListTimesheet
{
    public class GetListTimesheetQuery : IRequest<GetListTimesheetQueryResult>
    {
        public string? Month { get; set; }

        public int? Year { get; set; } 
    }
}
