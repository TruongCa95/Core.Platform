namespace TimeSheetManagement.Helper
{
    public class TimeHelper
    {
        public static string GenerateTimesheetName(DateTime date)
        {
            return $"ITS_{date:yyyyMMdd}";
        }
    }
}
