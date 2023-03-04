using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace community_institute_API.Migrations
{
    public partial class AddNametoAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Admins");
        }
    }
}
