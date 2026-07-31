using Domain.Entities.TimeSheet;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using TimeSheetManagement.Helper;

namespace TimeSheetManagement.Commands.CreateTimeSheets
{
    public class CreateTimeSheetCommandHandler : IRequestHandler<CreateTimesheetCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateTimeSheetCommandHandler> _logger;
        public CreateTimeSheetCommandHandler(IUnitOfWork unitOfWork, ILogger<CreateTimeSheetCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateTimesheetCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var timesheet = new TimeSheet
                {
                    Id = Guid.NewGuid(),
                    Name = TimeHelper.GenerateTimesheetName(request.Date),
                    Date = request.Date,
                    Description = request.Description,
                };
                var relationships = request.Classrooms.Select(classroom => new ClassRoomTimeSheet
                {
                    TimeSheetId = timesheet.Id,
                    ClassRoomId = classroom.ClassroomId,
                    NumberOfStudent = classroom.NumberOfStudent,
                });

                var timesheetReview = request.TimesheetReviews.Select(review => new TimesheetReview
                {
                    Progress = review.Progress,
                    Review = review.Review,
                    StudentId = review.StudentId,
                    TimesheetId = timesheet.Id,
                });

                await _unitOfWork.TimeSheets.AddAsync(timesheet);
                await _unitOfWork.ClassRoomTimeSheets.AddRangeAsync(relationships);
                await _unitOfWork.TimesheetReviews.AddRangeAsync(timesheetReview);
                await _unitOfWork.CompleteAsync();
                return timesheet.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating timesheet");
                throw;
            }
        }     
    }
}
