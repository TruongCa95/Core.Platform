using TimeSheetManagement.DTO;

namespace TimeSheetManagement.Queries.GetListTimesheet
{
    public class PagedTimesheetResult
    {
        public List<TimesheetResult> Results { get; set; } = new List<TimesheetResult>();

        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }
    }

    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = new List<T>();

        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }
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
