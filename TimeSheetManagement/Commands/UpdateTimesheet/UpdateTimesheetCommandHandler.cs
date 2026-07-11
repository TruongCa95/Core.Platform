using Domain.Entities.TimeSheet;
using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeSheetManagement.Helper;

namespace TimeSheetManagement.Commands.UpdateTimesheet
{
    public class UpdateTimesheetCommandHandler : IRequestHandler<UpdateTimesheetCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTimesheetCommandHandler(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }
        public async Task<bool> Handle(UpdateTimesheetCommand request, CancellationToken cancellationToken)
        {
            var timesheet = await _unitOfWork.TimeSheets.GetListByCondition(x => x.IsActive && x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (timesheet == null)
            {
                return false;
            }

            timesheet.UpdatedDate = DateTime.UtcNow;
            timesheet.Description = request.Description;
            timesheet.Date = request.Date;
            timesheet.Name = TimeHelper.GenerateTimesheetName(request.Date);
            await _unitOfWork.TimeSheets.UpdateAsync(timesheet);

            // Replace the classroom links when the caller supplies them so the edit form
            // can change the classroom and/or number of students on a record.
            if (request.Classrooms != null && request.Classrooms.Any())
            {
                var existingRelationships = await _unitOfWork.ClassRoomTimeSheets
                    .GetListByConditionAsync(x => x.TimeSheetId == request.Id);
                if (existingRelationships.Any())
                {
                    await _unitOfWork.ClassRoomTimeSheets.DeleteByIdsAsync(existingRelationships.Select(x => x.Id));
                }

                var relationships = request.Classrooms.Select(classroom => new ClassRoomTimeSheet
                {
                    TimeSheetId = timesheet.Id,
                    ClassRoomId = classroom.ClassroomId,
                    NumberOfStudent = classroom.NumberOfStudent,
                });
                await _unitOfWork.ClassRoomTimeSheets.AddRangeAsync(relationships);
            }

            // Replace the reviews with the set from the form (allows adding, editing and removing).
            var existingReviews = await _unitOfWork.TimesheetReviews
                .GetListByConditionAsync(x => x.TimesheetId == request.Id);
            if (existingReviews.Any())
            {
                await _unitOfWork.TimesheetReviews.DeleteByIdsAsync(existingReviews.Select(x => x.Id));
            }

            if (request.TimesheetReviews != null && request.TimesheetReviews.Any())
            {
                var reviews = request.TimesheetReviews.Select(review => new TimesheetReview
                {
                    Progress = review.Progress,
                    Review = review.Review,
                    StudentId = review.StudentId,
                    TimesheetId = timesheet.Id,
                });
                await _unitOfWork.TimesheetReviews.AddRangeAsync(reviews);
            }

            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
