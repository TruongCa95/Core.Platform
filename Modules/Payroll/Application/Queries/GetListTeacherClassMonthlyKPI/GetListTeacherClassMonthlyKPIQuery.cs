using MediatR;
using TimeSheetManagement.DTO;

namespace TimeSheetManagement.Queries.GetListTeacherClassMonthlyKPI
{
    public class GetListTeacherClassMonthlyKPIQuery : IRequest<List<TeacherClassMonthlyKPIDTO>>
    {
        public Guid? ClassroomId { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
    }
}
