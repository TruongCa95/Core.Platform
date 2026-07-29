using MediatR;
using TimeSheetManagement.DTO;

namespace TimeSheetManagement.Queries.GetListSalary
{
    public class GetListSalaryQuery : IRequest<List<SalaryDTO>>
    {
    }
}
