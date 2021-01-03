using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class addOneToOneFluentBookAndBookDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookDetails_Books_Book_Id",
                table: "Fluent_BookDetails");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_BookDetails_Book_Id",
                table: "Fluent_BookDetails");

            migrationBuilder.DropColumn(
                name: "Book_Id",
                table: "Fluent_BookDetails");

            migrationBuilder.AddColumn<int>(
                name: "BookDetail_Id",
                table: "Fluent_Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Books_BookDetail_Id",
                table: "Fluent_Books",
                column: "BookDetail_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Books_Fluent_BookDetails_BookDetail_Id",
                table: "Fluent_Books",
                column: "BookDetail_Id",
                principalTable: "Fluent_BookDetails",
                principalColumn: "BookDetail_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Books_Fluent_BookDetails_BookDetail_Id",
                table: "Fluent_Books");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_Books_BookDetail_Id",
                table: "Fluent_Books");

            migrationBuilder.DropColumn(
                name: "BookDetail_Id",
                table: "Fluent_Books");

            migrationBuilder.AddColumn<int>(
                name: "Book_Id",
                table: "Fluent_BookDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_BookDetails_Book_Id",
                table: "Fluent_BookDetails",
                column: "Book_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookDetails_Books_Book_Id",
                table: "Fluent_BookDetails",
                column: "Book_Id",
                principalTable: "Books",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
