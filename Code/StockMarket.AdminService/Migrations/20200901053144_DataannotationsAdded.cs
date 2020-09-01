using Microsoft.EntityFrameworkCore.Migrations;

namespace StockMarket.AdminService.Migrations
{
    public partial class DataannotationsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockPrices_CompanyStockExchanges_CompanyStockExchangeCompanyId_CompanyStockExchangeStockExchangeCode",
                table: "StockPrices");

            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "StockPrices",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "StockPrices",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyStockExchangeStockExchangeCode",
                table: "StockPrices",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyStockExchangeCompanyId",
                table: "StockPrices",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StockExchanges",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompayName",
                table: "Companies",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StockPrices_CompanyStockExchanges_CompanyStockExchangeCompanyId_CompanyStockExchangeStockExchangeCode",
                table: "StockPrices",
                columns: new[] { "CompanyStockExchangeCompanyId", "CompanyStockExchangeStockExchangeCode" },
                principalTable: "CompanyStockExchanges",
                principalColumns: new[] { "CompanyId", "StockExchangeCode" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockPrices_CompanyStockExchanges_CompanyStockExchangeCompanyId_CompanyStockExchangeStockExchangeCode",
                table: "StockPrices");

            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "StockPrices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "StockPrices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CompanyStockExchangeStockExchangeCode",
                table: "StockPrices",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "CompanyStockExchangeCompanyId",
                table: "StockPrices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StockExchanges",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CompayName",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_StockPrices_CompanyStockExchanges_CompanyStockExchangeCompanyId_CompanyStockExchangeStockExchangeCode",
                table: "StockPrices",
                columns: new[] { "CompanyStockExchangeCompanyId", "CompanyStockExchangeStockExchangeCode" },
                principalTable: "CompanyStockExchanges",
                principalColumns: new[] { "CompanyId", "StockExchangeCode" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
