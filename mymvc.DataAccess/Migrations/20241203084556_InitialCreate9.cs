using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mymvc.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monitors_Courses_CourseId",
                table: "Monitors");

            migrationBuilder.DropForeignKey(
                name: "FK_Monitors_Lecturers_LID",
                table: "Monitors");

            migrationBuilder.AddForeignKey(
                name: "FK_Monitors_Courses_CourseId",
                table: "Monitors",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Monitors_Lecturers_LID",
                table: "Monitors",
                column: "LID",
                principalTable: "Lecturers",
                principalColumn: "LID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monitors_Courses_CourseId",
                table: "Monitors");

            migrationBuilder.DropForeignKey(
                name: "FK_Monitors_Lecturers_LID",
                table: "Monitors");

            migrationBuilder.AddForeignKey(
                name: "FK_Monitors_Courses_CourseId",
                table: "Monitors",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Monitors_Lecturers_LID",
                table: "Monitors",
                column: "LID",
                principalTable: "Lecturers",
                principalColumn: "LID");
        }
    }
}
