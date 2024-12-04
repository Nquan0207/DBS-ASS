using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;



#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace mymvc.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Student4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.Sql("SET IDENTITY_INSERT Students ON");


            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Mssv = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Mssv);
                });


            migrationBuilder.CreateTable(
                name: "CreateSchedules",
                columns: table => new
                {
                    Mssv = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleID = table.Column<string>(type: "nvarchar(max)", nullable: false),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateSchedules", x => x.Mssv);
                });




            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Mssv, Name" },
                values: new object[,]
                {
                    {   "123" , 123},
                    {   "234",  234 },
                    {   "345",  345 }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Mssv  ", "ScheduleID" },
                values: new object[,]
                {
                    { 1, 1},
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_",
                table: "Schedules",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            //migrationBuilder.DropTable(
            //    name: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
