using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeSheetManagement.Queries.GetListTimesheet;

namespace TimeSheetManagement.Queries.GetListStudent
{
    public class GetListStudentQueryHandler : IRequestHandler<GetListStudentQuery, PagedResult<GetListStudentQueryResult>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetListStudentQueryHandler(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PagedResult<GetListStudentQueryResult>> Handle(GetListStudentQuery request, CancellationToken cancellationToken)
        {
            var query = _unitOfWork.Students.GetListByCondition(x => x.IsActive)
                .OrderByDescending(x => x.CreatedDate)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var search = request.Search.Trim();
                query = query.Where(x => x.Name.Contains(search) || x.Grade.Contains(search) || x.Review.Contains(search));
            }

            var totalCount = await query.CountAsync(cancellationToken);
            var page = request.Page <= 0 ? 1 : request.Page;
            var pageSize = request.PageSize <= 0 ? 20 : request.PageSize;
            var students = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);

            return new PagedResult<GetListStudentQueryResult>
            {
                Items = students.Select(s => new GetListStudentQueryResult
                {
                    Id = s.Id,
                    Name = s.Name,
                    Grade = s.Grade,
                    Review = s.Review
                }).ToList(),
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };
        }
    }
}
