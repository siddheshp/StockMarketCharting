using Microsoft.EntityFrameworkCore.Migrations;

namespace StockMarket.AdminService.Migrations
{
    public partial class addDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyStockExchange_Companies_CompanyId",
                table: "CompanyStockExchange");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyStockExchange_StockExchanges_StockExchangeCode",
                table: "CompanyStockExchange");

            migrationBuilder.DropForeignKey(
                name: "FK_StockPrices_Companies_CompanyId",
                table: "StockPrices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyStockExchange",
                table: "CompanyStockExchange");

            migrationBuilder.DropColumn(
                name: "StockExchangeId",
                table: "StockPrices");

            migrationBuilder.RenameTable(
                name: "CompanyStockExchange",
                newName: "CompanyStockExchanges");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyStockExchange_StockExchangeCode",
                table: "CompanyStockExchanges",
                newName: "IX_CompanyStockExchanges_StockExchangeCode");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "StockPrices",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CompanyStockExchangeCompanyId",
                table: "StockPrices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyStockExchangeStockExchangeCode",
                table: "StockPrices",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyStockExchanges",
                table: "CompanyStockExchanges",
                columns: new[] { "CompanyId", "StockExchangeCode" });

            migrationBuilder.CreateIndex(
                name: "IX_StockPrices_CompanyStockExchangeCompanyId_CompanyStockExchangeStockExchangeCode",
                table: "StockPrices",
                columns: new[] { "CompanyStockExchangeCompanyId", "CompanyStockExchangeStockExchangeCode" });

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyStockExchanges_Companies_CompanyId",
                table: "CompanyStockExchanges",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyStockExchanges_StockExchanges_StockExchangeCode",
                table: "CompanyStockExchanges",
                column: "StockExchangeCode",
                principalTable: "StockExchanges",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockPrices_Companies_CompanyId",
                table: "StockPrices",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockPrices_CompanyStockExchanges_CompanyStockExchangeCompanyId_CompanyStockExchangeStockExchangeCode",
                table: "StockPrices",
                columns: new[] { "CompanyStockExchangeCompanyId", "CompanyStockExchangeStockExchangeCode" },
                principalTable: "CompanyStockExchanges",
                principalColumns: new[] { "CompanyId", "StockExchangeCode" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyStockExchanges_Companies_CompanyId",
                table: "CompanyStockExchanges");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyStockExchanges_StockExchanges_StockExchangeCode",
                table: "CompanyStockExchanges");

            migrationBuilder.DropForeignKey(
                name: "FK_StockPrices_Companies_CompanyId",
                table: "StockPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_StockPrices_CompanyStockExchanges_CompanyStockExchangeCompanyId_CompanyStockExchangeStockExchangeCode",
                table: "StockPrices");

            migrationBuilder.DropIndex(
                name: "IX_StockPrices_CompanyStockExchangeCompanyId_CompanyStockExchangeStockExchangeCode",
                table: "StockPrices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyStockExchanges",
                table: "CompanyStockExchanges");

            migrationBuilder.DropColumn(
                name: "CompanyStockExchangeCompanyId",
                table: "StockPrices");

            migrationBuilder.DropColumn(
                name: "CompanyStockExchangeStockExchangeCode",
                table: "StockPrices");

            migrationBuilder.RenameTable(
                name: "CompanyStockExchanges",
                newName: "CompanyStockExchange");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyStockExchanges_StockExchangeCode",
                table: "CompanyStockExchange",
                newName: "IX_CompanyStockExchange_StockExchangeCode");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "StockPrices",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StockExchangeId",
                table: "StockPrices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyStockExchange",
                table: "CompanyStockExchange",
                columns: new[] { "CompanyId", "StockExchangeCode" });

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyStockExchange_Companies_CompanyId",
                table: "CompanyStockExchange",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyStockExchange_StockExchanges_StockExchangeCode",
                table: "CompanyStockExchange",
                column: "StockExchangeCode",
                principalTable: "StockExchanges",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockPrices_Companies_CompanyId",
                table: "StockPrices",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
