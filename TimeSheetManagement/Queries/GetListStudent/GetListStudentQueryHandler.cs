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

            // Load the active classroom enrolments for the students on this page so the client
            // can pre-populate the "classes" field when editing.
            var studentIds = students.Select(s => s.Id).ToList();
            var enrolments = await _unitOfWork.StudentClasses
                .GetListByConditionAsync(x => x.IsActive && studentIds.Contains(x.StudentId));
            var classIdsByStudent = enrolments
                .GroupBy(x => x.StudentId)
                .ToDictionary(g => g.Key, g => g.Select(e => e.ClassId).ToList());

            return new PagedResult<GetListStudentQueryResult>
            {
                Items = students.Select(s => new GetListStudentQueryResult
                {
                    Id = s.Id,
                    Name = s.Name,
                    Grade = s.Grade,
                    Review = s.Review,
                    ClassroomIds = classIdsByStudent.TryGetValue(s.Id, out var ids) ? ids : new List<Guid>()
                }).ToList(),
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };
        }
    }
}
