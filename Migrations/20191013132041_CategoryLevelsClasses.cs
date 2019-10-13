using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class CategoryLevelsClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetCategories_Level1Categories_Level2CategoryId",
                table: "BudgetCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetCategories_Level1Categories_Level3CategoryId",
                table: "BudgetCategories");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Level1Categories");

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

            migrationBuilder.CreateTable(
                name: "Level3Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level3Categories", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetCategories_Level2Categories_Level2CategoryId",
                table: "BudgetCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetCategories_Level3Categories_Level3CategoryId",
                table: "BudgetCategories");

            migrationBuilder.DropTable(
                name: "Level2Categories");

            migrationBuilder.DropTable(
                name: "Level3Categories");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Level1Categories",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetCategories_Level1Categories_Level2CategoryId",
                table: "BudgetCategories",
                column: "Level2CategoryId",
                principalTable: "Level1Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetCategories_Level1Categories_Level3CategoryId",
                table: "BudgetCategories",
                column: "Level3CategoryId",
                principalTable: "Level1Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
