using Microsoft.EntityFrameworkCore.Migrations;

namespace StockMarket.AdminService.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockPrices_StockExchanges_StockExchangeId",
                table: "StockPrices");

            migrationBuilder.DropIndex(
                name: "IX_StockPrices_StockExchangeId",
                table: "StockPrices");

            migrationBuilder.AlterColumn<string>(
                name: "StockExchangeId",
                table: "StockPrices",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyCodeId",
                table: "StockPrices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockExchangeId1",
                table: "StockPrices",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockPrices_StockExchangeId1",
                table: "StockPrices",
                column: "StockExchangeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StockPrices_StockExchanges_StockExchangeId1",
                table: "StockPrices",
                column: "StockExchangeId1",
                principalTable: "StockExchanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockPrices_StockExchanges_StockExchangeId1",
                table: "StockPrices");

            migrationBuilder.DropIndex(
                name: "IX_StockPrices_StockExchangeId1",
                table: "StockPrices");

            migrationBuilder.DropColumn(
                name: "CompanyCodeId",
                table: "StockPrices");

            migrationBuilder.DropColumn(
                name: "StockExchangeId1",
                table: "StockPrices");

            migrationBuilder.AlterColumn<int>(
                name: "StockExchangeId",
                table: "StockPrices",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockPrices_StockExchangeId",
                table: "StockPrices",
                column: "StockExchangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockPrices_StockExchanges_StockExchangeId",
                table: "StockPrices",
                column: "StockExchangeId",
                principalTable: "StockExchanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
