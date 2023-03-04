using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace community_institute_API.Migrations
{
    public partial class AddacdimcidtoproffandTA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AcademicId",
                table: "TAs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AcademicId",
                table: "Professors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Professors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcademicId",
                table: "TAs");

            migrationBuilder.DropColumn(
                name: "AcademicId",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Professors");
        }
    }
}
