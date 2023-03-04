using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace community_institute_API.Migrations
{
    public partial class addAtrbutestoStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AcademicId",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GPA",
                table: "Students",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "year",
                table: "Students",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcademicId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GPA",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "year",
                table: "Students");
        }
    }
}
