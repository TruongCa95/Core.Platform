using Domain.Entities.TimeSheet;
using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace TimeSheetManagement.Commands.UpsertTeacherClassMonthlyKPI
{
    public class UpsertTeacherClassMonthlyKPICommandHandler : IRequestHandler<UpsertTeacherClassMonthlyKPICommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertTeacherClassMonthlyKPICommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(UpsertTeacherClassMonthlyKPICommand request, CancellationToken cancellationToken)
        {
            var classroom = await _unitOfWork.Classrooms.GetByIdAsync(request.ClassroomId);
            if (classroom == null || classroom.Status != Domain.Enums.ClassRoomStatusEnums.Active)
            {
                return Guid.Empty;
            }

            var existing = await _unitOfWork.TeacherClassMonthlyKPIs.GetAll()
                .FirstOrDefaultAsync(x => x.ClassroomId == request.ClassroomId 
                                       && x.Year == request.Year 
                                       && x.Month == request.Month, cancellationToken);

            if (existing != null)
            {
                existing.KPI = request.KPI;
                existing.Note = request.Note ?? string.Empty;
                existing.IsActive = true;
                existing.UpdatedDate = DateTime.UtcNow;
                await _unitOfWork.TeacherClassMonthlyKPIs.UpdateAsync(existing);
                await _unitOfWork.CompleteAsync();
                return existing.Id;
            }
            else
            {
                var newEntity = new TeacherClassMonthlyKPI
                {
                    Id = Guid.NewGuid(),
                    ClassroomId = request.ClassroomId,
                    Year = request.Year,
                    Month = request.Month,
                    KPI = request.KPI,
                    Note = request.Note ?? string.Empty,
                    IsActive = true,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                };
                await _unitOfWork.TeacherClassMonthlyKPIs.AddAsync(newEntity);
                await _unitOfWork.CompleteAsync();
                return newEntity.Id;
            }
        }
    }
}
