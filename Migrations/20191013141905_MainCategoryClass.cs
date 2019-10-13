using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class MainCategoryClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetCategories_Level1Categories_Level1CategoryId",
                table: "BudgetCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetCategories_Level2Categories_Level2CategoryId",
                table: "BudgetCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetCategories_Level3Categories_Level3CategoryId",
                table: "BudgetCategories");

            migrationBuilder.DropTable(
                name: "Level1Categories");

            migrationBuilder.DropTable(
                name: "Level2Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Level3Categories",
                table: "Level3Categories");

            migrationBuilder.RenameTable(
                name: "Level3Categories",
                newName: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Categories",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetCategories_Categories_Level1CategoryId",
                table: "BudgetCategories",
                column: "Level1CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetCategories_Categories_Level2CategoryId",
                table: "BudgetCategories",
                column: "Level2CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetCategories_Categories_Level3CategoryId",
                table: "BudgetCategories",
                column: "Level3CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetCategories_Categories_Level1CategoryId",
                table: "BudgetCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetCategories_Categories_Level2CategoryId",
                table: "BudgetCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetCategories_Categories_Level3CategoryId",
                table: "BudgetCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Level3Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Level3Categories",
                table: "Level3Categories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Level1Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level1Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Level2Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level2Categories", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetCategories_Level1Categories_Level1CategoryId",
                table: "BudgetCategories",
                column: "Level1CategoryId",
                principalTable: "Level1Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetCategories_Level2Categories_Level2CategoryId",
                table: "BudgetCategories",
                column: "Level2CategoryId",
                principalTable: "Level2Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetCategories_Level3Categories_Level3CategoryId",
                table: "BudgetCategories",
                column: "Level3CategoryId",
                principalTable: "Level3Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
