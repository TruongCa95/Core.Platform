using Domain.Repositories;
using MediatR;

namespace TimeSheetManagement.Commands.UpdateStudents
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateStudentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _unitOfWork.Students.GetOne(x => x.IsActive && x.Id == request.Id);
            if (student != null)
            {
                student.Name = request.Name ?? string.Empty;
                student.Grade = request.Grade ?? string.Empty;
                student.Review = request.Review ?? string.Empty;
                await _unitOfWork.Students.UpdateAsync(student);
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
