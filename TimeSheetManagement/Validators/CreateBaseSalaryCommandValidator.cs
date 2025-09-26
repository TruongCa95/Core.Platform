using FluentValidation;
using TimeSheetManagement.Commands.CreateBaseSalary;

namespace TimeSheetManagement.Validators
{
    public class CreateBaseSalaryCommandValidator : AbstractValidator<CreateBaseSalaryCommand>
    {
        public CreateBaseSalaryCommandValidator()
        {
            RuleFor(command => command.Level)
                .IsInEnum().WithMessage("Invalid level.");

            RuleFor(command => command.Money)
                .GreaterThan(0).WithMessage("Money must be greater than 0.");

            RuleFor(command => command.NumberOfStudent)
                .GreaterThanOrEqualTo(0).WithMessage("Number of students cannot be negative.");
        }
    }
}
