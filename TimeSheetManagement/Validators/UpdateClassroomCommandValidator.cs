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

            RuleFor(x => x.ClassCode)
                .NotEmpty().WithMessage("Class code is required.")
                .MaximumLength(50).WithMessage("Class code cannot exceed 50 characters.");

            RuleFor(x => x.ClassName)
                .NotEmpty().WithMessage("Class name is required.")
                .MaximumLength(100).WithMessage("Class name cannot exceed 100 characters.");

            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("Location is required.")
                .MaximumLength(100).WithMessage("Location cannot exceed 100 characters.");

            RuleFor(x => x.NumberOfStudent)
                .GreaterThan(0).WithMessage("Number of students must be greater than 0.");

            RuleFor(x => x.Level)
                .IsInEnum().WithMessage("Invalid level.");
        }
    }
}
