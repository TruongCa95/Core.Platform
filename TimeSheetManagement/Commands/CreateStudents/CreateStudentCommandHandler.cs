using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.TimeSheet;
using Domain.Repositories;
using MediatR;

namespace TimeSheetManagement.Commands.CreateStudents
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateStudentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var isExist = await _unitOfWork.Students.GetOne(x => x.IsActive && x.Name == request.Name);
            if (isExist != null) 
            {
                throw new DuplicateNameException();
            } 
                
            var student = new Students
            {
                Grade = request.Grade ?? string.Empty,
                Review = request.Review ?? string.Empty,
                Name = request.Name,
            };

            await _unitOfWork.Students.AddAsync(student);
            if (request.ClassroomIds != null && request.ClassroomIds.Any())
            {
                var relationship = request.ClassroomIds.Distinct().Select(x => new StudentClasses
                {
                    StudentId = student.Id,
                    ClassId = x
                });

                await _unitOfWork.StudentClasses.AddRangeAsync(relationship);
            }
            await _unitOfWork.CompleteAsync();
            return student.Id;
        }
    }
}
