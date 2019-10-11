using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class budgetCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BudgetCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryLevel1Id = table.Column<int>(nullable: true),
                    CategoryLevel2Id = table.Column<int>(nullable: true),
                    CategoryLevel3Id = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetCategories_Categories_CategoryLevel1Id",
                        column: x => x.CategoryLevel1Id,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BudgetCategories_Categories_CategoryLevel2Id",
                        column: x => x.CategoryLevel2Id,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BudgetCategories_Categories_CategoryLevel3Id",
                        column: x => x.CategoryLevel3Id,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetCategories_CategoryLevel1Id",
                table: "BudgetCategories",
                column: "CategoryLevel1Id");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetCategories_CategoryLevel2Id",
                table: "BudgetCategories",
                column: "CategoryLevel2Id");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetCategories_CategoryLevel3Id",
                table: "BudgetCategories",
                column: "CategoryLevel3Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetCategories");
        }
    }
}
