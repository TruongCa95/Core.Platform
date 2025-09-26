using Domain.Enums;
using MediatR;

namespace TimeSheetManagement.Commands.CreateBaseSalary
{
    public class CreateBaseSalaryCommand : IRequest<Guid>
    {
        public LevelEnums Level { get; set; }

        public decimal Money { get; set; }

        public int NumberOfStudent {  get; set; }
    }
}
