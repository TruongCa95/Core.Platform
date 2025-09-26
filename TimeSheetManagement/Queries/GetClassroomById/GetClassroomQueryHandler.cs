using Domain.Entities.TimeSheet;
using Domain.Repositories;
using MediatR;

namespace TimeSheetManagement.Queries.GetListClassroom
{
    public class GetClassroomQueryHandler : IRequestHandler<GetClassroomQuery, GetClassroomQueryResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetClassroomQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetClassroomQueryResult> Handle(GetClassroomQuery request, CancellationToken cancellationToken)
        {
            var classroom = await _unitOfWork.Classrooms.GetByIdAsync(request.ClassrooId);

            return classroom == null
                ? throw new KeyNotFoundException()
                : new GetClassroomQueryResult
            {
                Id = classroom.Id,
                ClassCode = classroom.ClassCode,
                ClassName = classroom.ClassName,
                NumberOfStudent = classroom.NumberOfStudent,
            };
        }
    }
}
