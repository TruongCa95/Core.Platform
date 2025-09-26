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
            if (classroom != null)
            {
                classroom.ClassName = request.ClassName ?? string.Empty;
                classroom.NumberOfStudent = request.NumberOfStudent;
                await _unitOfWork.Classrooms.UpdateAsync(classroom);
                await _unitOfWork.CompleteAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
