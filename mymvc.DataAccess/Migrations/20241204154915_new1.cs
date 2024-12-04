using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace mymvc.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class new1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monitors");

            migrationBuilder.DropTable(
                name: "Lecturers");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Mssv = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Mssv);
                });

            migrationBuilder.CreateTable(
                name: "CreateSchedules",
                columns: table => new
                {
                    Mssv = table.Column<int>(type: "int", nullable: false),
                    ScheduleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateSchedules", x => new { x.ScheduleID, x.Mssv });
                    table.ForeignKey(
                        name: "FK_CreateSchedules_Schedules_ScheduleID",
                        column: x => x.ScheduleID,
                        principalTable: "Schedules",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreateSchedules_Students_Mssv",
                        column: x => x.Mssv,
                        principalTable: "Students",
                        principalColumn: "Mssv",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Mssv", "Name" },
                values: new object[,]
                {
                    { 1, "Test" },
                    { 2, "Hung" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreateSchedules_Mssv",
                table: "CreateSchedules",
                column: "Mssv");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreateSchedules");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.CreateTable(
                name: "Lecturers",
                columns: table => new
                {
                    LID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DEPARTMENT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FULL_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PHONE_NUMBER = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturers", x => x.LID);
                });

            migrationBuilder.CreateTable(
                name: "Monitors",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    LID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitors", x => new { x.CourseId, x.LID });
                    table.ForeignKey(
                        name: "FK_Monitors_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Monitors_Lecturers_LID",
                        column: x => x.LID,
                        principalTable: "Lecturers",
                        principalColumn: "LID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Lecturers",
                columns: new[] { "LID", "DEPARTMENT", "EMAIL", "FULL_NAME", "PHONE_NUMBER" },
                values: new object[,]
                {
                    { 1, "Engineering", "UIroh@hcmut.edu.vn", "Uncle Iroh", "0987654321" },
                    { 2, "Computer Science", "EFMark@hcmut.edu.vn", "Mark Edward Fischbach", "0135791113" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Monitors_LID",
                table: "Monitors",
                column: "LID");
        }
    }
}
