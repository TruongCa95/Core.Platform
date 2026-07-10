using MediatR;

namespace TimeSheetManagement.Queries.GetListTimesheet
{
    public class GetListTimesheetQuery : IRequest<PagedTimesheetResult>
    {
        public string? Month { get; set; }

        public int? Year { get; set; }

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 20;
    }
}
