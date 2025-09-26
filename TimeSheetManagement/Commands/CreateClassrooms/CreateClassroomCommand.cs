using Domain.Enums;
using MediatR;

namespace TimeSheetManagement.Commands.CreateClassroom
{
    public class CreateClassroomCommand : IRequest<Guid>
    {

        public string ClassCode { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public string ClassName { get; set; } = string.Empty;

        public LevelEnums Level { get; set; }

        public int NumberOfStudent { get; set; } = 1;


    }
}
