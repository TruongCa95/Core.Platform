using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClassroomStudentsRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassRoomTimeSheets_ClassRooms_ClassRoomId",
                table: "ClassRoomTimeSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassRoomTimeSheets_TimeSheets_TimeSheetId",
                table: "ClassRoomTimeSheets");

            migrationBuilder.AlterColumn<Guid>(
                name: "TimeSheetId",
                table: "ClassRoomTimeSheets",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClassRoomId",
                table: "ClassRoomTimeSheets",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRoomTimeSheets_ClassRooms_ClassRoomId",
                table: "ClassRoomTimeSheets",
                column: "ClassRoomId",
                principalTable: "ClassRooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRoomTimeSheets_TimeSheets_TimeSheetId",
                table: "ClassRoomTimeSheets",
                column: "TimeSheetId",
                principalTable: "TimeSheets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassRoomTimeSheets_ClassRooms_ClassRoomId",
                table: "ClassRoomTimeSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassRoomTimeSheets_TimeSheets_TimeSheetId",
                table: "ClassRoomTimeSheets");

            migrationBuilder.AlterColumn<Guid>(
                name: "TimeSheetId",
                table: "ClassRoomTimeSheets",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClassRoomId",
                table: "ClassRoomTimeSheets",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRoomTimeSheets_ClassRooms_ClassRoomId",
                table: "ClassRoomTimeSheets",
                column: "ClassRoomId",
                principalTable: "ClassRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRoomTimeSheets_TimeSheets_TimeSheetId",
                table: "ClassRoomTimeSheets",
                column: "TimeSheetId",
                principalTable: "TimeSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
