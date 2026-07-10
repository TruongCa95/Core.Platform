using FluentValidation;
using TimeSheetManagement.Commands.UpdateClassrooms;

namespace TimeSheetManagement.Validators
{
    public class UpdateClassroomCommandValidator : AbstractValidator<UpdateClassroomCommand>
    {
        public UpdateClassroomCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Classroom id is required.");

            RuleFor(x => x.ClassName)
                .NotEmpty().WithMessage("Class name is required.")
                .MaximumLength(100).WithMessage("Class name cannot exceed 100 characters.");

            RuleFor(x => x.NumberOfStudent)
                .GreaterThan(0).WithMessage("Number of students must be greater than 0.");
        }
    }
}
