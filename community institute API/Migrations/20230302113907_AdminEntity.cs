using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace community_institute_API.Migrations
{
    public partial class AdminEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_admins_Users_UserId",
                table: "admins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_admins",
                table: "admins");

            migrationBuilder.RenameTable(
                name: "admins",
                newName: "Admins");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Admins",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_admins_UserId",
                table: "Admins",
                newName: "IX_Admins_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Users_UserId",
                table: "Admins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_UserId",
                table: "Admins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.RenameTable(
                name: "Admins",
                newName: "admins");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "admins",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Admins_UserId",
                table: "admins",
                newName: "IX_admins_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_admins",
                table: "admins",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_admins_Users_UserId",
                table: "admins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
