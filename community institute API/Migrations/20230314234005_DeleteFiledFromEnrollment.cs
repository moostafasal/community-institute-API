using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace community_institute_API.Migrations
{
    public partial class DeleteFiledFromEnrollment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Grades_GradesId",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_GradesId",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "GradesId",
                table: "Enrollments");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_EnrollmentId",
                table: "Grades",
                column: "EnrollmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Enrollments_EnrollmentId",
                table: "Grades",
                column: "EnrollmentId",
                principalTable: "Enrollments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Enrollments_EnrollmentId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_EnrollmentId",
                table: "Grades");

            migrationBuilder.AddColumn<int>(
                name: "GradesId",
                table: "Enrollments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_GradesId",
                table: "Enrollments",
                column: "GradesId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Grades_GradesId",
                table: "Enrollments",
                column: "GradesId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
