using Domain.Repositories;
using MediatR;
using System.Data;

namespace TimeSheetManagement.Commands.UpdateClassrooms
{
    public class UpdateClassroomCommandHandler : IRequestHandler<UpdateClassroomCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateClassroomCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateClassroomCommand request, CancellationToken cancellationToken)
        {
            var classroom = await _unitOfWork.Classrooms.GetOne(x => x.IsActive && x.Id == request.Id);
            if (classroom == null)
            {
                return false;
            }

            // When the class code changes, make sure no other active classroom already uses it.
            if (!string.IsNullOrWhiteSpace(request.ClassCode) && request.ClassCode != classroom.ClassCode)
            {
                var duplicate = await _unitOfWork.Classrooms
                    .GetOne(x => x.IsActive && x.Id != request.Id && x.ClassCode == request.ClassCode);
                if (duplicate != null)
                {
                    throw new DuplicateNameException();
                }
                classroom.ClassCode = request.ClassCode;
            }

            classroom.ClassName = request.ClassName ?? string.Empty;
            classroom.Location = request.Location ?? string.Empty;
            classroom.NumberOfStudent = request.NumberOfStudent;
            classroom.Level = request.Level;
            classroom.Status = request.Status;
            classroom.UpdatedDate = DateTime.UtcNow;

            await _unitOfWork.Classrooms.UpdateAsync(classroom);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
