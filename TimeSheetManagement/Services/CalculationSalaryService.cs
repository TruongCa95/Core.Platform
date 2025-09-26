using Domain.Enums;
using Domain.Repositories;
using TimeSheetManagement.DTO;

namespace TimeSheetManagement.Services
{
    public class CalculationSalaryService : ICalculationSalaryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CalculationSalaryService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public List<CalculationSalaryResponse> CalculationSalary(List<CalculationSalaryRequest> requests)
        {
            int max = 99;
            var result = new List<CalculationSalaryResponse>();
            if (requests.Count != 0) 
            {
                var salaries = _unitOfWork.Salaries.GetAll();

                foreach (CalculationSalaryRequest request in requests)
                {
                    var salaryList = salaries.Where(x => x.Level == request.level).ToList();
                    if (salaryList.Count == 0) continue;

                    decimal salaryAmount;
                    if (request.numberOfStudent >= max)
                    {
                        var maxSalary = salaryList.MaxBy(x => x.NumberOfStudent);
                        salaryAmount = maxSalary?.Money ?? 0;
                    }
                    else
                    {
                        var matchedSalary = salaryList.FirstOrDefault(x => x.NumberOfStudent == request.numberOfStudent);
                        salaryAmount = matchedSalary?.Money ?? 0;
                    }

                    result.Add(new CalculationSalaryResponse
                    {
                        ClassroomId = request.ClassroomId,
                        Salary = salaryAmount * CalculateKi(request.ki),
                    });
                }
            }

            return result;
        }

        public decimal CalculateKi(KiEnums ki)
        {
            return ki switch
            {
                KiEnums.APlus => 1.25m,
                KiEnums.A => 1.1m,
                KiEnums.C => 0.8m,
                KiEnums.D => 0.5m,
                _ => 1.0m,
            };
        }
    }
}
