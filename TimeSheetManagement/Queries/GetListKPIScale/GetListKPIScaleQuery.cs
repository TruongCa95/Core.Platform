using MediatR;
using TimeSheetManagement.DTO;

namespace TimeSheetManagement.Queries.GetListKPIScale
{
    public class GetListKPIScaleQuery : IRequest<List<KPIScaleDTO>>
    {
    }
}
