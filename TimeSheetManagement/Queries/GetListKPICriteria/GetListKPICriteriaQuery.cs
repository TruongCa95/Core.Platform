using MediatR;
using TimeSheetManagement.DTO;

namespace TimeSheetManagement.Queries.GetListKPICriteria
{
    public class GetListKPICriteriaQuery : IRequest<List<KPICriteriaDTO>>
    {
    }
}
