using FluentValidation;
using TimeSheetManagement.Commands.CreateStudents;

namespace TimeSheetManagement.Validators
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Student name is required.")
                .MaximumLength(100).WithMessage("Student name cannot exceed 100 characters.");

            RuleFor(x => x.Grade)
                .NotEmpty().WithMessage("Grade is required.")
                .MaximumLength(50).WithMessage("Grade cannot exceed 50 characters.");

            RuleFor(x => x.Review)
                .MaximumLength(500).WithMessage("Review cannot exceed 500 characters.");

            RuleFor(x => x.ClassroomIds)
                .NotNull().WithMessage("Classroom list cannot be null.");
        }
    }
}
