using Infrastructure.Command;
using Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using TimeSheetManagement.Commands.CreateBaseSalary;
using TimeSheetManagement.Commands.CreateClassroom;
using TimeSheetManagement.Commands.CreateStudents;
using TimeSheetManagement.Commands.CreateTimeSheets;
using TimeSheetManagement.Commands.DeleteClassroom;
using TimeSheetManagement.Commands.DeleteStudent;
using TimeSheetManagement.Commands.UpdateClassrooms;
using TimeSheetManagement.Commands.UpdateStudents;
using TimeSheetManagement.Commands.UpdateTimesheet;
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
        public async Task<ActionResult<PagedTimesheetResult>> GetTimeSheets([FromQuery] string? month, [FromQuery] int? year, [FromQuery] int page = 1, [FromQuery] int pageSize = 20)
        {
            var result = await _query.Send(new GetListTimesheetQuery
            {
                Month = month,
                Year = year,
                Page = page,
                PageSize = pageSize
            });
            if (result == null || !result.Results.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTimeSheet([FromRoute] Guid id, [FromBody] UpdateTimesheetCommand command)
        {
            if (command.Id == Guid.Empty)
            {
                command.Id = id;
            }

            var result = await _command.Send(command);
            return result ? Ok(true) : NotFound();
        }

        [HttpPost("Students")]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentCommand command)
        {
            var id = await _command.Send(command);
            return Ok(id);
        }

        [HttpGet("Students")]
        public async Task<ActionResult<PagedResult<GetListStudentQueryResult>>> GetStudents([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] string? search = null)
        {
            var result = await _query.Send(new GetListStudentQuery
            {
                Page = page,
                PageSize = pageSize,
                Search = search
            });
            if (result == null || !result.Items.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("Students/{id}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] Guid id, [FromBody] UpdateStudentCommand command)
        {
            if (command.Id == Guid.Empty)
            {
                command.Id = id;
            }

            var result = await _command.Send(command);
            return result ? Ok(true) : NotFound();
        }

        [HttpDelete("Students/{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid id)
        {
            var result = await _command.Send(new DeleteStudentByIdCommand { Id = id });
            return result ? Ok(true) : NotFound();
        }

        [HttpPost("Classrooms")]
        public async Task<IActionResult> CreateClassroom([FromBody] CreateClassroomCommand command)
        {
            var id = await _command.Send(command);
            return Ok(id);
        }

        [HttpGet("Classrooms")]
        public async Task<ActionResult<PagedResult<GetListClassroomQueryResult>>> GetClassrooms([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] string? search = null)
        {
            var result = await _query.Send(new GetListClassroomQuery
            {
                Page = page,
                PageSize = pageSize,
                Search = search
            });
            if (result == null || !result.Items.Any())
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

        [HttpPut("Classrooms/{id}")]
        public async Task<IActionResult> UpdateClassroom([FromRoute] Guid id, [FromBody] UpdateClassroomCommand command)
        {
            if (command.Id == Guid.Empty)
            {
                command.Id = id;
            }

            var result = await _command.Send(command);
            return result ? Ok(true) : NotFound();
        }

        [HttpDelete("Classrooms/{id}")]
        public async Task<IActionResult> DeleteClassroom([FromRoute] Guid id)
        {
            var result = await _command.Send(new DeleteClassroomByIdCommand { Id = id });
            return result ? Ok(true) : NotFound();
        }

        [HttpPost("Salary")]
        public async Task<IActionResult> CreateSalary([FromBody] CreateBaseSalaryCommand command)
        {
            var id = await _command.Send(command);
            return Ok(id);
        }
    }
}
