using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Migrations
{
    /// <inheritdoc />
    public partial class first4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_categories_CategoriesCategoryId",
                table: "books");

            migrationBuilder.DropForeignKey(
                name: "FK_books_publishers_PublishersPublisherId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "BookCotegoryid",
                table: "books");

            migrationBuilder.DropColumn(
                name: "BookpulishedId",
                table: "books");

            migrationBuilder.RenameColumn(
                name: "BookpublishedYear",
                table: "books",
                newName: "BookPublishedYear");

            migrationBuilder.RenameColumn(
                name: "PublishersPublisherId",
                table: "books",
                newName: "BookPublishedId");

            migrationBuilder.RenameColumn(
                name: "CategoriesCategoryId",
                table: "books",
                newName: "BookCategoryId");

            migrationBuilder.RenameColumn(
                name: "BookAuther",
                table: "books",
                newName: "BookAuthor");

            migrationBuilder.RenameIndex(
                name: "IX_books_PublishersPublisherId",
                table: "books",
                newName: "IX_books_BookPublishedId");

            migrationBuilder.RenameIndex(
                name: "IX_books_CategoriesCategoryId",
                table: "books",
                newName: "IX_books_BookCategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "BookName",
                table: "books",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_books_categories_BookCategoryId",
                table: "books",
                column: "BookCategoryId",
                principalTable: "categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_books_publishers_BookPublishedId",
                table: "books",
                column: "BookPublishedId",
                principalTable: "publishers",
                principalColumn: "PublisherId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_categories_BookCategoryId",
                table: "books");

            migrationBuilder.DropForeignKey(
                name: "FK_books_publishers_BookPublishedId",
                table: "books");

            migrationBuilder.RenameColumn(
                name: "BookPublishedYear",
                table: "books",
                newName: "BookpublishedYear");

            migrationBuilder.RenameColumn(
                name: "BookPublishedId",
                table: "books",
                newName: "PublishersPublisherId");

            migrationBuilder.RenameColumn(
                name: "BookCategoryId",
                table: "books",
                newName: "CategoriesCategoryId");

            migrationBuilder.RenameColumn(
                name: "BookAuthor",
                table: "books",
                newName: "BookAuther");

            migrationBuilder.RenameIndex(
                name: "IX_books_BookPublishedId",
                table: "books",
                newName: "IX_books_PublishersPublisherId");

            migrationBuilder.RenameIndex(
                name: "IX_books_BookCategoryId",
                table: "books",
                newName: "IX_books_CategoriesCategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "BookName",
                table: "books",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<int>(
                name: "BookCotegoryid",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookpulishedId",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_books_categories_CategoriesCategoryId",
                table: "books",
                column: "CategoriesCategoryId",
                principalTable: "categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_books_publishers_PublishersPublisherId",
                table: "books",
                column: "PublishersPublisherId",
                principalTable: "publishers",
                principalColumn: "PublisherId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
