using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace TimeSheetManagement.Queries.GetListStudent
{
    public class GetListStudentQueryHandler : IRequestHandler<GetListStudentQuery, List<GetListStudentQueryResult>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetListStudentQueryHandler(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<GetListStudentQueryResult>> Handle(GetListStudentQuery request, CancellationToken cancellationToken)
        {
            var students = await _unitOfWork.Students.GetAll().OrderByDescending(x => x.CreatedDate).ToListAsync();

            return students.Select(s => new GetListStudentQueryResult
            {
                Id = s.Id,
                Name = s.Name,
                Grade = s.Grade,
                Review = s.Review
            }).ToList();
        }
    }
}
