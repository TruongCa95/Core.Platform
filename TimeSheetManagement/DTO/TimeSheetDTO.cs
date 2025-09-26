using Domain.Enums;

namespace TimeSheetManagement.DTO
{
    public class TimeSheetDTO
    {
        public string Classcode { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        public int NumberOfStudent {  get; set; }

        public LevelEnums Level { get; set; }

        public decimal Allowance { get; set; }

        public decimal Salary { get; set; }

        public decimal TotalSalary {  get; set; }

        public List<TimesheetReviewDTO> Reviews { get; set; } = new List<TimesheetReviewDTO>();
    }
}
