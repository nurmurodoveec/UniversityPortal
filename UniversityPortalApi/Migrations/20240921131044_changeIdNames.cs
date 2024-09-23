using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityPortalApi.Migrations
{
    /// <inheritdoc />
    public partial class changeIdNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimetableId",
                table: "Timetables",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Subjects",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Students",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NewsId",
                table: "News",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GradeId",
                table: "Grades",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Timetables",
                newName: "TimetableId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Subjects",
                newName: "SubjectId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Students",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "News",
                newName: "NewsId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Grades",
                newName: "GradeId");
        }
    }
}
