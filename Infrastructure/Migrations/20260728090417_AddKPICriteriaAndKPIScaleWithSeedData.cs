using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddKPICriteriaAndKPIScaleWithSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KPICriterias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Criteria = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Point = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KPICriterias", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "KPIScales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Grade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Score = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Factor = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KPIScales", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "KPICriterias",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Criteria", "DisplayOrder", "IsActive", "Point", "Type", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thầy giáo của ITS chỉ đạo, hướng dẫn học sinh có thành tích đặc biệt xuất sắc ở các cuộc thi của Trường, của Quốc gia", 1, true, "+40đ", "plus", "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thầy giáo có đóng góp về góp ý, ý tưởng, tham gia trực tiếp hiện thực hóa ý tưởng đạt hiệu quả vượt bậc", 2, true, "+40đ", "plus", "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thầy giáo có những cống hiến quên mình vì sự phát triển của Tổ chức được quản lý trực tiếp đánh giá xuất sắc / đề xuất từ quản lý trực tiếp", 3, true, "+40đ", "plus", "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lớp không có học sinh ở dưới điểm 9 trong các bài kiểm tra, điểm thi học kỳ trên trường", 4, true, "+25đ", "plus", "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phụ huynh ý kiến khen / giới thiệu thêm học sinh cho lớp / trung tâm", 5, true, "+15đ", "plus", "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đi dạy đầy đủ 100% các buổi dạy được phân công trong tháng", 6, true, "+5đ", "plus", "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lớp không có học sinh ở dưới điểm 8 trong các bài kiểm tra", 7, true, "+10đ", "plus", "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lớp có trên 80% học sinh điểm thi trên 8", 8, true, "+10đ", "plus", "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lớp có 1 hoặc 2 học sinh có điểm kiểm tra / thi từ 7 đến < 8 điểm", 9, true, "-5đ", "minus", "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lớp có 3 hoặc 4 học sinh có điểm kiểm tra / thi từ 7 đến < 8 điểm", 10, true, "-10đ", "minus", "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000011"), "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Từ chối dạy những buổi theo lịch đã đăng ký", 11, true, "-10đ", "minus", "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lớp có 5 hoặc 6 bạn học sinh có điểm kiểm tra / thi từ 7 đến < 8 điểm", 12, true, "-15đ", "minus", "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000013"), "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lớp có 1 hoặc 2 học sinh có điểm kiểm tra / thi từ 6 đến < 7 điểm", 13, true, "-10đ", "minus", "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000014"), "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lớp có 3 hoặc 4 học sinh có điểm kiểm tra / thi từ 6 đến < 7 điểm", 14, true, "-15đ", "minus", "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000015"), "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lớp có 5 hoặc 6 bạn học sinh có điểm kiểm tra / thi từ 6 đến < 7 điểm", 15, true, "-20đ", "minus", "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000016"), "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lớp có bạn học sinh có điểm kiểm tra / thi < 6 điểm", 16, true, "-40đ", "minus", "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "KPIScales",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "DisplayOrder", "Factor", "Grade", "IsActive", "Score", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000101"), "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xuất sắc vượt bậc", 1, 1.4m, "Ki A*", true, "140đ", "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000102"), "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xuất sắc", 2, 1.25m, "Ki A", true, "125đ", "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000103"), "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khá giỏi", 3, 1.1m, "Ki B+", true, "110đ", "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000104"), "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đạt chuẩn (Mặc định)", 4, 1.0m, "Ki B", true, "100đ", "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000105"), "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cần cố gắng", 5, 0.9m, "Ki C+", true, "90đ", "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000106"), "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chưa đạt", 6, 0.8m, "Ki C", true, "80đ", "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000107"), "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vi phạm / Kém", 7, 0.65m, "Ki D", true, "60đ", "", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KPICriterias");

            migrationBuilder.DropTable(
                name: "KPIScales");
        }
    }
}
