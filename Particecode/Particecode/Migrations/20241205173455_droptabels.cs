using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Particecode.Migrations
{
    /// <inheritdoc />
    public partial class droptabels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "subjects",
                newName: "SubjectId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "students",
                newName: "StudentId");
            

        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "subjects",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "students",
                newName: "Id");
        }
    }
}
