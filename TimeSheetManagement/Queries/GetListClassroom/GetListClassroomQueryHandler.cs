using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeSheetManagement.Queries.GetListTimesheet;

namespace TimeSheetManagement.Queries.GetListClassroom
{
    public class GetListClassroomQueryHandler : IRequestHandler<GetListClassroomQuery, PagedResult<GetListClassroomQueryResult>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetListClassroomQueryHandler(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PagedResult<GetListClassroomQueryResult>> Handle(GetListClassroomQuery request, CancellationToken cancellationToken)
        {
            var query = _unitOfWork.Classrooms.GetListByCondition(x => x.IsActive)
                .OrderByDescending(x => x.CreatedDate)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var search = request.Search.Trim();
                query = query.Where(x => x.ClassName.Contains(search) || x.ClassCode.Contains(search) || x.Location.Contains(search));
            }

            var totalCount = await query.CountAsync(cancellationToken);
            var page = request.Page <= 0 ? 1 : request.Page;
            var pageSize = request.PageSize <= 0 ? 20 : request.PageSize;
            var classrooms = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);

            return new PagedResult<GetListClassroomQueryResult>
            {
                Items = classrooms.Select(x => new GetListClassroomQueryResult
                {
                    Id = x.Id,
                    ClassCode = x.ClassCode,
                    ClassName = x.ClassName,
                    Location = x.Location,
                    NumberOfStudent = x.NumberOfStudent,
                    Level = (int)x.Level
                }).ToList(),
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };
        }
    }
}
