using Domain.Enums;
using TimeSheetManagement.DTO;

namespace TimeSheetManagement.Services
{
    public interface ICalculationSalaryService
    {
        List<CalculationSalaryResponse> CalculationSalary(List<CalculationSalaryRequest> requests);
    }
}
