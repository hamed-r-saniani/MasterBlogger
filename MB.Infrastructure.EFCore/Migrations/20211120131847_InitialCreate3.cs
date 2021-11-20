using Microsoft.EntityFrameworkCore.Migrations;

namespace MB.Infrastructure.EFCore.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ArticleCategories",
                newName: "ArticleCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ArticleCategoryId",
                table: "ArticleCategories",
                newName: "Id");
        }
    }
}
