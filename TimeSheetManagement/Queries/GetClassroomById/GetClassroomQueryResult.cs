namespace TimeSheetManagement.Queries.GetListClassroom
{
    public class GetClassroomQueryResult
    {
        public Guid Id { get; set; }

        public string ClassName { get; set; } =  string.Empty;

        public string ClassCode { get; set; } = string.Empty;

        public int NumberOfStudent {  get; set; }
    }
}
