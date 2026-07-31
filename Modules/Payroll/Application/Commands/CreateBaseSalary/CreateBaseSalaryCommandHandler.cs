using Domain.Entities.TimeSheet;
using Domain.Repositories;
using FluentValidation;
using MediatR;

namespace TimeSheetManagement.Commands.CreateBaseSalary
{
    public class CreateBaseSalaryCommandHandler : IRequestHandler<CreateBaseSalaryCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateBaseSalaryCommand> _validator;
        public CreateBaseSalaryCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateBaseSalaryCommand> validator) 
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }
        public async Task<Guid> Handle(CreateBaseSalaryCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var salary = new Salary
            {
                Id = Guid.NewGuid(),
                Level = request.Level,
                Money = request.Money,
                NumberOfStudent = request.NumberOfStudent
            };
            await _unitOfWork.Salaries.AddAsync(salary);
            await _unitOfWork.CompleteAsync();
            return salary.Id;
        }
    }
}
