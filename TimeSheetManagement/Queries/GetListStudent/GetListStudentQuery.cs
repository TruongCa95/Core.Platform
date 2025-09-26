using MediatR;

namespace TimeSheetManagement.Queries.GetListStudent
{
    public class GetListStudentQuery : IRequest<List<GetListStudentQueryResult>>
    {
    }
}
