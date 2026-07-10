using Domain.Enums;
using MediatR;

namespace TimeSheetManagement.Commands.UpdateClassrooms
{
    public class UpdateClassroomCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public string? ClassCode { get; set; }

        public string? ClassName { get; set; }

        public string? Location { get; set; }

        public int NumberOfStudent { get; set; }

        public LevelEnums Level { get; set; }
    }
}
