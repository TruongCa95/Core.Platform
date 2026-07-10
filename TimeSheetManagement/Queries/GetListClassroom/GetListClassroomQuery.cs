using MediatR;
using TimeSheetManagement.Queries.GetListTimesheet;

namespace TimeSheetManagement.Queries.GetListClassroom
{
    public class GetListClassroomQuery : IRequest<PagedResult<GetListClassroomQueryResult>>
    {
        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 20;

        public string? Search { get; set; }
    }
}
