using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNumberOfStudentToTimesheetRealtionship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfStudent",
                table: "TimeSheets");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfStudent",
                table: "ClassRoomTimeSheets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfStudent",
                table: "ClassRoomTimeSheets");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfStudent",
                table: "TimeSheets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
