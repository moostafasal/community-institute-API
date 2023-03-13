using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace community_institute_API.Migrations
{
    public partial class updateRelationWithGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_clases_ClassId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_ClassId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Groups");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "clases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_clases_GroupId",
                table: "clases",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_clases_Groups_GroupId",
                table: "clases",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clases_Groups_GroupId",
                table: "clases");

            migrationBuilder.DropIndex(
                name: "IX_clases_GroupId",
                table: "clases");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "clases");

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ClassId",
                table: "Groups",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_clases_ClassId",
                table: "Groups",
                column: "ClassId",
                principalTable: "clases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
