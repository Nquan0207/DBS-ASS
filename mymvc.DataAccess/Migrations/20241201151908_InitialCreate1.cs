using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace mymvc.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lecturers",
                columns: table => new
                {
                    LID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FULL_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PHONE_NUMBER = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DEPARTMENT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturers", x => x.LID);
                });

            migrationBuilder.InsertData(
                table: "Lecturers",
                columns: new[] { "LID", "DEPARTMENT", "EMAIL", "FULL_NAME", "PHONE_NUMBER" },
                values: new object[,]
                {
                    { 1, "Engineering", "UIroh@hcmut.edu.vn", "Uncle Iroh", "0987654321" },
                    { 2, "Computer Science", "EFMark@hcmut.edu.vn", "Mark Edward Fischbach", "0135791113" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lecturers");
        }
    }
}
