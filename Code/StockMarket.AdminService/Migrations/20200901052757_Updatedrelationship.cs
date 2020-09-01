using Microsoft.EntityFrameworkCore.Migrations;

namespace StockMarket.AdminService.Migrations
{
    public partial class Updatedrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockPrices_Companies_CompanyId",
                table: "StockPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_StockPrices_StockExchanges_StockExchangeCode",
                table: "StockPrices");

            migrationBuilder.DropIndex(
                name: "IX_StockPrices_CompanyId",
                table: "StockPrices");

            migrationBuilder.DropIndex(
                name: "IX_StockPrices_StockExchangeCode",
                table: "StockPrices");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "StockPrices");

            migrationBuilder.DropColumn(
                name: "StockExchangeCode",
                table: "StockPrices");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "StockPrices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StockExchangeCode",
                table: "StockPrices",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockPrices_CompanyId",
                table: "StockPrices",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_StockPrices_StockExchangeCode",
                table: "StockPrices",
                column: "StockExchangeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_StockPrices_Companies_CompanyId",
                table: "StockPrices",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockPrices_StockExchanges_StockExchangeCode",
                table: "StockPrices",
                column: "StockExchangeCode",
                principalTable: "StockExchanges",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
