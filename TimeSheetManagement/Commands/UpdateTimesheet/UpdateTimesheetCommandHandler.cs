using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var timesheet = await _unitOfWork.TimeSheets.GetListByCondition(x => x.IsActive &&  x.Id == request.Id).FirstOrDefaultAsync();
            if (timesheet != null)
            {
                timesheet.UpdatedDate = DateTime.UtcNow;
                timesheet.Description = request.Description;
                timesheet.Date = request.Date;
                timesheet.Name = TimeHelper.GenerateTimesheetName(request.Date);
                await _unitOfWork.TimeSheets.UpdateAsync(timesheet);
                await _unitOfWork.CompleteAsync();
                return true;
            }
            else
            {
                return false;
                throw new KeyNotFoundException();
            }

        }
    }
}
