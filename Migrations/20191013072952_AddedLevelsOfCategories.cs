using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class AddedLevelsOfCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetCategories_Categories_CategoryLevel1Id",
                table: "BudgetCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetCategories_Categories_CategoryLevel2Id",
                table: "BudgetCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetCategories_Categories_CategoryLevel3Id",
                table: "BudgetCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.RenameColumn(
                name: "CategoryLevel3Id",
                table: "BudgetCategories",
                newName: "Level3CategoryId");

            migrationBuilder.RenameColumn(
                name: "CategoryLevel2Id",
                table: "BudgetCategories",
                newName: "Level2CategoryId");

            migrationBuilder.RenameColumn(
                name: "CategoryLevel1Id",
                table: "BudgetCategories",
                newName: "Level1CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_BudgetCategories_CategoryLevel3Id",
                table: "BudgetCategories",
                newName: "IX_BudgetCategories_Level3CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_BudgetCategories_CategoryLevel2Id",
                table: "BudgetCategories",
                newName: "IX_BudgetCategories_Level2CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_BudgetCategories_CategoryLevel1Id",
                table: "BudgetCategories",
                newName: "IX_BudgetCategories_Level1CategoryId");

            migrationBuilder.CreateTable(
                name: "Level1Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level1Categories", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetCategories_Level1Categories_Level1CategoryId",
                table: "BudgetCategories",
                column: "Level1CategoryId",
                principalTable: "Level1Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetCategories_Level1Categories_Level1CategoryId",
                table: "BudgetCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetCategories_Level1Categories_Level2CategoryId",
                table: "BudgetCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetCategories_Level1Categories_Level3CategoryId",
                table: "BudgetCategories");

            migrationBuilder.DropTable(
                name: "Level1Categories");

            migrationBuilder.RenameColumn(
                name: "Level3CategoryId",
                table: "BudgetCategories",
                newName: "CategoryLevel3Id");

            migrationBuilder.RenameColumn(
                name: "Level2CategoryId",
                table: "BudgetCategories",
                newName: "CategoryLevel2Id");

            migrationBuilder.RenameColumn(
                name: "Level1CategoryId",
                table: "BudgetCategories",
                newName: "CategoryLevel1Id");

            migrationBuilder.RenameIndex(
                name: "IX_BudgetCategories_Level3CategoryId",
                table: "BudgetCategories",
                newName: "IX_BudgetCategories_CategoryLevel3Id");

            migrationBuilder.RenameIndex(
                name: "IX_BudgetCategories_Level2CategoryId",
                table: "BudgetCategories",
                newName: "IX_BudgetCategories_CategoryLevel2Id");

            migrationBuilder.RenameIndex(
                name: "IX_BudgetCategories_Level1CategoryId",
                table: "BudgetCategories",
                newName: "IX_BudgetCategories_CategoryLevel1Id");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryLevel = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetCategories_Categories_CategoryLevel1Id",
                table: "BudgetCategories",
                column: "CategoryLevel1Id",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetCategories_Categories_CategoryLevel2Id",
                table: "BudgetCategories",
                column: "CategoryLevel2Id",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetCategories_Categories_CategoryLevel3Id",
                table: "BudgetCategories",
                column: "CategoryLevel3Id",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
