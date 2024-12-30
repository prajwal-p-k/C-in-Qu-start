using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Migrations
{
    /// <inheritdoc />
    public partial class first3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categories_books_BooksBookId",
                table: "categories");

            migrationBuilder.DropForeignKey(
                name: "FK_publishers_books_BooksBookId",
                table: "publishers");

            migrationBuilder.DropIndex(
                name: "IX_publishers_BooksBookId",
                table: "publishers");

            migrationBuilder.DropIndex(
                name: "IX_categories_BooksBookId",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "BooksBookId",
                table: "publishers");

            migrationBuilder.DropColumn(
                name: "BooksBookId",
                table: "categories");

            migrationBuilder.AddColumn<int>(
                name: "CategoriesCategoryId",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PublishersPublisherId",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_books_CategoriesCategoryId",
                table: "books",
                column: "CategoriesCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_books_PublishersPublisherId",
                table: "books",
                column: "PublishersPublisherId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_categories_CategoriesCategoryId",
                table: "books");

            migrationBuilder.DropForeignKey(
                name: "FK_books_publishers_PublishersPublisherId",
                table: "books");

            migrationBuilder.DropIndex(
                name: "IX_books_CategoriesCategoryId",
                table: "books");

            migrationBuilder.DropIndex(
                name: "IX_books_PublishersPublisherId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "CategoriesCategoryId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "PublishersPublisherId",
                table: "books");

            migrationBuilder.AddColumn<int>(
                name: "BooksBookId",
                table: "publishers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BooksBookId",
                table: "categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_publishers_BooksBookId",
                table: "publishers",
                column: "BooksBookId");

            migrationBuilder.CreateIndex(
                name: "IX_categories_BooksBookId",
                table: "categories",
                column: "BooksBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_books_BooksBookId",
                table: "categories",
                column: "BooksBookId",
                principalTable: "books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_publishers_books_BooksBookId",
                table: "publishers",
                column: "BooksBookId",
                principalTable: "books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
