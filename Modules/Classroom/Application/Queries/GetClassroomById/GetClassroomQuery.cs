using MediatR;

namespace TimeSheetManagement.Queries.GetListClassroom
{
    public class GetClassroomQuery : IRequest<GetClassroomQueryResult>
    {
        public Guid ClassrooId { get; set; }
    }
}
