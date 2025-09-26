using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLevelToClassroom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "ClassRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "ClassRooms");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
