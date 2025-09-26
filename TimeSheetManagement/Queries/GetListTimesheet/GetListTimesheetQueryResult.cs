using TimeSheetManagement.DTO;

namespace TimeSheetManagement.Queries.GetListTimesheet
{
    public class GetListTimesheetQueryResult
    {

        public List<TimesheetResult> Results { get; set; } = new List<TimesheetResult>();
    }

    public class TimesheetResult
    {
        public string Month { get; set; } = string.Empty;

        public List<TimeSheetDTO> TimeSheet { get; set; } = new List<TimeSheetDTO>();

        public decimal AllowanceTotal {  get; set; }

        public decimal GrossTotal { get; set; }

        public decimal TaxforCharity { get; set; }

        public decimal NetTotal { get; set; }
    }
}
