using FluentValidation;
using TimeSheetManagement.Commands.UpdateTimesheet;

namespace TimeSheetManagement.Validators
{
    public class UpdateTimesheetCommandValidator : AbstractValidator<UpdateTimesheetCommand>
    {
        public UpdateTimesheetCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Timesheet id is required.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Date is required.");
        }
    }
}
