using MediatR;

namespace TimeSheetManagement.Queries.GetListClassroom
{
    public class GetListClassroomQuery :IRequest<List<GetListClassroomQueryResult>>
    {
    }
}
