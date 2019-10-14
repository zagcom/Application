﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class updateModelBudgetCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Level3CategoryId",
                table: "BudgetCategories",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Level2CategoryId",
                table: "BudgetCategories",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Level1CategoryId",
                table: "BudgetCategories",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Level3CategoryId",
                table: "BudgetCategories",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Level2CategoryId",
                table: "BudgetCategories",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Level1CategoryId",
                table: "BudgetCategories",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
