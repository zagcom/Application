using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class UpdateProductsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BudgetCategoryId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_BudgetCategoryId",
                table: "Products",
                column: "BudgetCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_BudgetCategories_BudgetCategoryId",
                table: "Products",
                column: "BudgetCategoryId",
                principalTable: "BudgetCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_BudgetCategories_BudgetCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_BudgetCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BudgetCategoryId",
                table: "Products");
        }
    }
}
