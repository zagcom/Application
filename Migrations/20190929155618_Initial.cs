using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    EAN = table.Column<string>(nullable: true),
                    Unit = table.Column<int>(nullable: false),
                    Qty = table.Column<float>(nullable: false),
                    PhotoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "EAN", "Name", "PhotoPath", "Qty", "Unit" },
                values: new object[] { "g9IFYiz0iA", "5902294001518", "Oranżada Fantazja Czerwona 330ml", null, 1f, 0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "EAN", "Name", "PhotoPath", "Qty", "Unit" },
                values: new object[] { "r1PskoTkWF", "5902294004960", "Oranżada Fantazja Orange 330ml", null, 1f, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
