using Domain.Repositories;
using MediatR;

namespace TimeSheetManagement.Commands.DeleteTimesheet
{
    public class DeleteTimesheetByIdCommandHandler : IRequestHandler<DeleteTimesheetByIdCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTimesheetByIdCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteTimesheetByIdCommand request, CancellationToken cancellationToken)
        {
            var timesheet = await _unitOfWork.TimeSheets.GetOne(x => x.Id == request.Id);
            if (timesheet == null)
            {
                return false;
            }

            // Hard-delete the record and its related rows so nothing is left dangling.
            var relationships = await _unitOfWork.ClassRoomTimeSheets
                .GetListByConditionAsync(x => x.TimeSheetId == request.Id);
            if (relationships.Any())
            {
                await _unitOfWork.ClassRoomTimeSheets.DeleteByIdsAsync(relationships.Select(x => x.Id));
            }

            var reviews = await _unitOfWork.TimesheetReviews
                .GetListByConditionAsync(x => x.TimesheetId == request.Id);
            if (reviews.Any())
            {
                await _unitOfWork.TimesheetReviews.DeleteByIdsAsync(reviews.Select(x => x.Id));
            }

            await _unitOfWork.TimeSheets.DeleteAsync(timesheet.Id);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
