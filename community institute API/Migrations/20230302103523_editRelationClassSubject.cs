using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace community_institute_API.Migrations
{
    public partial class editRelationClassSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_clases_classid",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_classid",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "classid",
                table: "Subjects");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "clases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_clases_SubjectId",
                table: "clases",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_clases_Subjects_SubjectId",
                table: "clases",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clases_Subjects_SubjectId",
                table: "clases");

            migrationBuilder.DropIndex(
                name: "IX_clases_SubjectId",
                table: "clases");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "clases");

            migrationBuilder.AddColumn<int>(
                name: "classid",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_classid",
                table: "Subjects",
                column: "classid");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_clases_classid",
                table: "Subjects",
                column: "classid",
                principalTable: "clases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
