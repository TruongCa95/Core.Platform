using System.Data;
using Domain.Entities.TimeSheet;
using Domain.Repositories;
using MediatR;

namespace TimeSheetManagement.Commands.CreateClassroom
{
    public class CreateClassroomCommandHandler : IRequestHandler<CreateClassroomCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateClassroomCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateClassroomCommand request, CancellationToken cancellationToken)
        {
            var isExist = await _unitOfWork.Classrooms.GetOne(x => x.IsActive && x.ClassCode == request.ClassCode);
            if (isExist != null)
            {
                throw new DuplicateNameException();
            }
            var classroom = new ClassRoom
            {
                Id = Guid.NewGuid(),
                ClassCode = request.ClassCode,
                ClassName = request.ClassName,
                NumberOfStudent = request.NumberOfStudent,
                Location = request.Location,
                Level = request.Level
            };

            await _unitOfWork.Classrooms.AddAsync(classroom);
            await _unitOfWork.CompleteAsync();
            return classroom.Id;
        }
    }
}
