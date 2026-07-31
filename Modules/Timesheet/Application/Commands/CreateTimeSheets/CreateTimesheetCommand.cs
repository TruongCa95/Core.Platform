using MediatR;
using TimeSheetManagement.DTO;

namespace TimeSheetManagement.Commands.CreateTimeSheets
{
    public class CreateTimesheetCommand : IRequest<Guid>
    {

        public string Description { get; set; } = string.Empty;

        public DateTime Date { get; set; }
        
        public List<ClassroomDTO> Classrooms { get; set; } = new List<ClassroomDTO>();

        public List<TimesheetReviewDTO> TimesheetReviews { get; set; } = new List<TimesheetReviewDTO>();


    }
}
