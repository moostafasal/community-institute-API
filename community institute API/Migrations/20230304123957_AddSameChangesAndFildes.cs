﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace community_institute_API.Migrations
{
    public partial class AddSameChangesAndFildes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "Enrollments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ProfessorId",
                table: "Enrollments",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Professors_ProfessorId",
                table: "Enrollments",
                column: "ProfessorId",
                principalTable: "Professors",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Professors_ProfessorId",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_ProfessorId",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Enrollments");
        }
    }
}
