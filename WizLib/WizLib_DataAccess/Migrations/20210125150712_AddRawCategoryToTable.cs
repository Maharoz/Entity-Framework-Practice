using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class AddRawCategoryToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into tbl_category VALUES('Cat 1')");
            migrationBuilder.Sql("Insert into tbl_category VALUES('Cat 2')");
            migrationBuilder.Sql("Insert into tbl_category VALUES('Cat 3')");
            migrationBuilder.Sql("Insert into tbl_category VALUES('Cat 4')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
