﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mymvc.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monitors_Courses_LID",
                table: "Monitors");

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
                name: "FK_Monitors_Lecturers_LID",
                table: "Monitors");

            migrationBuilder.AddForeignKey(
                name: "FK_Monitors_Courses_LID",
                table: "Monitors",
                column: "LID",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
