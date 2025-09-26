using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace TimeSheetManagement.Queries.GetListClassroom
{
    public class GetListClassroomQueryHandler : IRequestHandler<GetListClassroomQuery, List<GetListClassroomQueryResult>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetListClassroomQueryHandler(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<GetListClassroomQueryResult>> Handle(GetListClassroomQuery request, CancellationToken cancellationToken)
        {
            var classrooms = await _unitOfWork.Classrooms.GetListByCondition(x => x.IsActive).OrderByDescending(x => x.CreatedDate).ToListAsync();
            if (classrooms.Count != 0)
            {
                return classrooms.Select(x => new GetListClassroomQueryResult
                {
                    Id = x.Id,
                    ClassCode = x.ClassCode,
                    ClassName = x.ClassName,
                    Location = x.Location,
                    NumberOfStudent = x.NumberOfStudent
                }).ToList();
            }
            else
            {
                return new List<GetListClassroomQueryResult>();
            }
        }
    }
}
