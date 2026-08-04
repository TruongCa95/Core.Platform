using BuildingBlocks.Security;
using Infrastructure.Command;
using Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using TimeSheetManagement.Commands.CreateBaseSalary;
using TimeSheetManagement.Commands.CreateClassroom;
using TimeSheetManagement.Commands.CreateStudents;
using TimeSheetManagement.Commands.CreateTimeSheets;
using TimeSheetManagement.Commands.DeleteClassroom;
using TimeSheetManagement.Commands.DeleteStudent;
using TimeSheetManagement.Commands.DeleteTimesheet;
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
        [HasPermission(PermissionCatalog.Timesheet.Dashboard.Write)]
        public async Task<IActionResult> CreateTimeSheet([FromBody] CreateTimesheetCommand command)
        {
            var id = await _command.Send(command);
            return Ok(id);
        }

        [HttpGet()]
        [HasPermission(PermissionCatalog.Timesheet.Dashboard.View)]
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
        [HasPermission(PermissionCatalog.Timesheet.Dashboard.Write)]
        public async Task<IActionResult> UpdateTimeSheet([FromRoute] Guid id, [FromBody] UpdateTimesheetCommand command)
        {
            if (command.Id == Guid.Empty)
            {
                command.Id = id;
            }

            var result = await _command.Send(command);
            return result ? Ok(true) : NotFound();
        }

        [HttpDelete("{id}")]
        [HasPermission(PermissionCatalog.Timesheet.Dashboard.Write)]
        public async Task<IActionResult> DeleteTimeSheet([FromRoute] Guid id)
        {
            var result = await _command.Send(new DeleteTimesheetByIdCommand { Id = id });
            return result ? Ok(true) : NotFound();
        }

        [HttpPost("Students")]
        [HasPermission(PermissionCatalog.Timesheet.Student.Write)]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentCommand command)
        {
            var id = await _command.Send(command);
            return Ok(id);
        }

        [HttpGet("Students")]
        [HasPermission(PermissionCatalog.Timesheet.Student.View)]
        public async Task<ActionResult<PagedResult<GetListStudentQueryResult>>> GetStudents(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 20,
            [FromQuery] string? search = null,
            [FromQuery] bool? isActive = null,
            [FromQuery] Guid? classroomId = null)
        {
            var result = await _query.Send(new GetListStudentQuery
            {
                Page = page,
                PageSize = pageSize,
                Search = search,
                IsActive = isActive,
                ClassroomId = classroomId
            });
            if (result == null || !result.Items.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("Students/{id}")]
        [HasPermission(PermissionCatalog.Timesheet.Student.Write)]
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
        [HasPermission(PermissionCatalog.Timesheet.Student.Write)]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid id)
        {
            var result = await _command.Send(new DeleteStudentByIdCommand { Id = id });
            return result ? Ok(true) : NotFound();
        }

        [HttpPost("Classrooms")]
        [HasPermission(PermissionCatalog.Timesheet.Classroom.Write)]
        public async Task<IActionResult> CreateClassroom([FromBody] CreateClassroomCommand command)
        {
            var id = await _command.Send(command);
            return Ok(id);
        }

        [HttpGet("Classrooms")]
        [HasPermission(PermissionCatalog.Timesheet.Classroom.View)]
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
        [HasPermission(PermissionCatalog.Timesheet.Classroom.View)]
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
        [HasPermission(PermissionCatalog.Timesheet.Classroom.Write)]
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
        [HasPermission(PermissionCatalog.Timesheet.Classroom.Write)]
        public async Task<IActionResult> DeleteClassroom([FromRoute] Guid id)
        {
            var result = await _command.Send(new DeleteClassroomByIdCommand { Id = id });
            return result ? Ok(true) : NotFound();
        }

        [HttpPost("Salary")]
        [HasPermission(PermissionCatalog.Timesheet.Salary.Write)]
        public async Task<IActionResult> CreateSalary([FromBody] CreateBaseSalaryCommand command)
        {
            var id = await _command.Send(command);
            return Ok(id);
        }

        [HttpGet("KPI")]
        [HasPermission(PermissionCatalog.Timesheet.Kpi.View)]
        public async Task<ActionResult<List<TimeSheetManagement.DTO.TeacherClassMonthlyKPIDTO>>> GetMonthlyKPIs(
            [FromQuery] Guid? classroomId,
            [FromQuery] int? year,
            [FromQuery] int? month)
        {
            var result = await _query.Send(new TimeSheetManagement.Queries.GetListTeacherClassMonthlyKPI.GetListTeacherClassMonthlyKPIQuery
            {
                ClassroomId = classroomId,
                Year = year,
                Month = month
            });
            return Ok(result ?? new List<TimeSheetManagement.DTO.TeacherClassMonthlyKPIDTO>());
        }

        [HttpPost("KPI")]
        [HasPermission(PermissionCatalog.Timesheet.Kpi.Write)]
        public async Task<IActionResult> UpsertMonthlyKPI([FromBody] TimeSheetManagement.Commands.UpsertTeacherClassMonthlyKPI.UpsertTeacherClassMonthlyKPICommand command)
        {
            var id = await _command.Send(command);
            if (id == Guid.Empty)
            {
                return BadRequest("Chỉ được đánh giá KPI cho các lớp học có trạng thái Hoạt động.");
            }
            return Ok(id);
        }

        [HttpDelete("KPI/{id}")]
        [HasPermission(PermissionCatalog.Timesheet.Kpi.Write)]
        public async Task<IActionResult> DeleteMonthlyKPI([FromRoute] Guid id)
        {
            var result = await _command.Send(new TimeSheetManagement.Commands.DeleteTeacherClassMonthlyKPI.DeleteTeacherClassMonthlyKPICommand { Id = id });
            return result ? Ok(true) : NotFound();
        }

        // KPI Criteria Endpoints
        [HttpGet("KPI/Criteria")]
        [HasPermission(PermissionCatalog.Timesheet.Kpi.View)]
        public async Task<IActionResult> GetKPICriteria()
        {
            var result = await _query.Send(new TimeSheetManagement.Queries.GetListKPICriteria.GetListKPICriteriaQuery());
            return Ok(result ?? new List<TimeSheetManagement.DTO.KPICriteriaDTO>());
        }

        [HttpPost("KPI/Criteria")]
        [HasPermission(PermissionCatalog.Timesheet.Kpi.Write)]
        public async Task<IActionResult> UpsertKPICriteria([FromBody] TimeSheetManagement.Commands.UpsertKPICriteria.UpsertKPICriteriaCommand command)
        {
            var id = await _command.Send(command);
            return Ok(id);
        }

        [HttpDelete("KPI/Criteria/{id}")]
        [HasPermission(PermissionCatalog.Timesheet.Kpi.Write)]
        public async Task<IActionResult> DeleteKPICriteria([FromRoute] Guid id)
        {
            var result = await _command.Send(new TimeSheetManagement.Commands.DeleteKPICriteria.DeleteKPICriteriaCommand(id));
            return result ? Ok(true) : NotFound();
        }

        // KPI Scale Endpoints
        [HttpGet("KPI/Scales")]
        [HasPermission(PermissionCatalog.Timesheet.Kpi.View)]
        public async Task<IActionResult> GetKPIScales()
        {
            var result = await _query.Send(new TimeSheetManagement.Queries.GetListKPIScale.GetListKPIScaleQuery());
            return Ok(result ?? new List<TimeSheetManagement.DTO.KPIScaleDTO>());
        }

        [HttpPost("KPI/Scales")]
        [HasPermission(PermissionCatalog.Timesheet.Kpi.Write)]
        public async Task<IActionResult> UpsertKPIScale([FromBody] TimeSheetManagement.Commands.UpsertKPIScale.UpsertKPIScaleCommand command)
        {
            var id = await _command.Send(command);
            return Ok(id);
        }

        [HttpDelete("KPI/Scales/{id}")]
        [HasPermission(PermissionCatalog.Timesheet.Kpi.Write)]
        public async Task<IActionResult> DeleteKPIScale([FromRoute] Guid id)
        {
            var result = await _command.Send(new TimeSheetManagement.Commands.DeleteKPIScale.DeleteKPIScaleCommand(id));
            return result ? Ok(true) : NotFound();
        }

        // Salary Configuration Endpoints
        [HttpGet("Salaries")]
        [HasPermission(PermissionCatalog.Timesheet.Salary.View)]
        public async Task<IActionResult> GetSalaries()
        {
            var result = await _query.Send(new TimeSheetManagement.Queries.GetListSalary.GetListSalaryQuery());
            return Ok(result ?? new List<TimeSheetManagement.DTO.SalaryDTO>());
        }

        [HttpPost("Salaries")]
        [HasPermission(PermissionCatalog.Timesheet.Salary.Write)]
        public async Task<IActionResult> UpsertSalary([FromBody] TimeSheetManagement.Commands.UpsertSalary.UpsertSalaryCommand command)
        {
            var id = await _command.Send(command);
            return Ok(id);
        }

        [HttpDelete("Salaries/{id}")]
        [HasPermission(PermissionCatalog.Timesheet.Salary.Write)]
        public async Task<IActionResult> DeleteSalary([FromRoute] Guid id)
        {
            var result = await _command.Send(new TimeSheetManagement.Commands.DeleteSalary.DeleteSalaryCommand(id));
            return result ? Ok(true) : NotFound();
        }
    }
}
