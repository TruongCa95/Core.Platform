using FluentValidation;
using TimeSheetManagement.Commands.CreateTimeSheets;

namespace TimeSheetManagement.Validators
{
    public class CreateTimesheetCommandValidator : AbstractValidator<CreateTimesheetCommand>
    {
        public CreateTimesheetCommandValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Date is required.");
        }
    }
}
