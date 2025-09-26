namespace TimeSheetManagement.Queries.GetListClassroom
{
    public class GetListClassroomQueryResult
    {
        public Guid Id { get; set; }

        public string ClassCode { get; set; } = string.Empty;

        public string ClassName { get; set; } = string.Empty;

        public string Location {  get; set; } = string.Empty;

        public int NumberOfStudent {  get; set; }

    }
}
