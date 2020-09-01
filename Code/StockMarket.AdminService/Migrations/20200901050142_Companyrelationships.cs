using Microsoft.EntityFrameworkCore.Migrations;

namespace StockMarket.AdminService.Migrations
{
    public partial class Companyrelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_StockExchanges_StockExchangeCode",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_StockExchangeCode",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "StockExchangeCode",
                table: "Companies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StockExchangeCode",
                table: "Companies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_StockExchangeCode",
                table: "Companies",
                column: "StockExchangeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_StockExchanges_StockExchangeCode",
                table: "Companies",
                column: "StockExchangeCode",
                principalTable: "StockExchanges",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
