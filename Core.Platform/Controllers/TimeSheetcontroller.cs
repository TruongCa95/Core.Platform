using Infrastructure.Command;
using Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using TimeSheetManagement.Commands.CreateBaseSalary;
using TimeSheetManagement.Commands.CreateClassroom;
using TimeSheetManagement.Commands.CreateStudents;
using TimeSheetManagement.Commands.CreateTimeSheets;
using TimeSheetManagement.Queries.GetListClassroom;
using TimeSheetManagement.Queries.GetListStudent;
using TimeSheetManagement.Queries.GetListTimesheet;

namespace Core.Platform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeSheetsController : ControllerBase
    {
        private readonly ICommandRunner _command;
        private readonly IQueryRunner _query;

        public TimeSheetsController(ICommandRunner command, IQueryRunner query)
        {
            _command = command;
            _query = query;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTimeSheet([FromBody] CreateTimesheetCommand command)
        {
            var id = await _command.Send(command);
            return Ok(id);
        }

        [HttpGet()]
        public async Task<ActionResult<GetListTimesheetQueryResult>> GetTimeSheets([FromQuery] string? month, [FromQuery] int? year)
        {
            var result = await _query.Send(new GetListTimesheetQuery
            {
                Month = month,
                Year = year,
            });
            if (result == null || !result.Results.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("Students")]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentCommand command)
        {
            var id = await _command.Send(command);
            return Ok(id);
        }

        [HttpGet("Students")]
        public async Task<ActionResult<GetListStudentQueryResult>> GetStudents()
        {
            var result = await _query.Send(new GetListStudentQuery
            {

            });
            if (result == null || !result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("Classrooms")]
        public async Task<IActionResult> CreateClassroom([FromBody] CreateClassroomCommand command)
        {
            var id = await _command.Send(command);
            return Ok(id);
        }

        [HttpGet("Classrooms")]
        public async Task<ActionResult<GetListClassroomQueryResult>> GetClassrooms()
        {
            var result = await _query.Send(new GetListClassroomQuery
            {

            });
            if (result == null || !result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("Classrooms/{id}")]
        public async Task<ActionResult<GetClassroomQueryResult>> GetClassrooms([FromRoute] Guid id)
        {
            var result = await _query.Send(new GetClassroomQuery
            {
                ClassrooId = id,
            });
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("Salary")]
        public async Task<IActionResult> CreateSalary([FromBody] CreateBaseSalaryCommand command)
        {
            var id = await _command.Send(command);
            return Ok(id);
        }
    }
}
