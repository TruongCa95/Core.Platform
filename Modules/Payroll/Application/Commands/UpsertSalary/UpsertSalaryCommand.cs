using Domain.Enums;
using MediatR;

namespace TimeSheetManagement.Commands.UpsertSalary
{
    public class UpsertSalaryCommand : IRequest<Guid>
    {
        public Guid? Id { get; set; }
        public decimal Money { get; set; }
        public LevelEnums Level { get; set; }
        public int NumberOfStudent { get; set; }
    }
}
