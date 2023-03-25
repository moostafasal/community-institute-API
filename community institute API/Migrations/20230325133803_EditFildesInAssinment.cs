using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace community_institute_API.Migrations
{
    public partial class EditFildesInAssinment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Assignments",
                newName: "FileUrl");

            migrationBuilder.AddColumn<int>(
                name: "classesId",
                table: "Assignments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "classid",
                table: "Assignments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_classesId",
                table: "Assignments",
                column: "classesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_clases_classesId",
                table: "Assignments",
                column: "classesId",
                principalTable: "clases",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_clases_classesId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_classesId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "classesId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "classid",
                table: "Assignments");

            migrationBuilder.RenameColumn(
                name: "FileUrl",
                table: "Assignments",
                newName: "Url");
        }
    }
}
