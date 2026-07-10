using MediatR;
using TimeSheetManagement.Queries.GetListTimesheet;

namespace TimeSheetManagement.Queries.GetListStudent
{
    public class GetListStudentQuery : IRequest<PagedResult<GetListStudentQueryResult>>
    {
        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 20;

        public string? Search { get; set; }
    }
}
