using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practice.Migrations
{
    /// <inheritdoc />
    public partial class new1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Subjects_SubjectId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Subjects",
                newName: "Subjects1");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Students2");

            migrationBuilder.RenameIndex(
                name: "IX_Students_SubjectId",
                table: "Students2",
                newName: "IX_Students2_SubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects1",
                table: "Subjects1",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students2",
                table: "Students2",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students2_Subjects1_SubjectId",
                table: "Students2",
                column: "SubjectId",
                principalTable: "Subjects1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students2_Subjects1_SubjectId",
                table: "Students2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects1",
                table: "Subjects1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students2",
                table: "Students2");

            migrationBuilder.RenameTable(
                name: "Subjects1",
                newName: "Subjects");

            migrationBuilder.RenameTable(
                name: "Students2",
                newName: "Students");

            migrationBuilder.RenameIndex(
                name: "IX_Students2_SubjectId",
                table: "Students",
                newName: "IX_Students_SubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Subjects_SubjectId",
                table: "Students",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
