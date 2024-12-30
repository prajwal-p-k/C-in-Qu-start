using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Particecode.Migrations
{
    /// <inheritdoc />
    public partial class afteredit4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSubject");

            migrationBuilder.RenameColumn(
                name: "SubjectName",
                table: "students",
                newName: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_students_SubjectId",
                table: "students",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_students_subjects_SubjectId",
                table: "students",
                column: "SubjectId",
                principalTable: "subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_subjects_SubjectId",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_students_SubjectId",
                table: "students");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "students",
                newName: "SubjectName");

            migrationBuilder.CreateTable(
                name: "StudentSubject",
                columns: table => new
                {
                    StudentsId = table.Column<int>(type: "int", nullable: false),
                    SubjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubject", x => new { x.StudentsId, x.SubjectsId });
                    table.ForeignKey(
                        name: "FK_StudentSubject_students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubject_subjects_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_SubjectsId",
                table: "StudentSubject",
                column: "SubjectsId");
        }
    }
}
