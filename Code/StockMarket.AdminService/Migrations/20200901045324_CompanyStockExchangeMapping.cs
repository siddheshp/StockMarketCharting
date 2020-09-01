using Microsoft.EntityFrameworkCore.Migrations;

namespace StockMarket.AdminService.Migrations
{
    public partial class CompanyStockExchangeMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyStockExchange",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false),
                    StockExchangeCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyStockExchange", x => new { x.CompanyId, x.StockExchangeCode });
                    table.ForeignKey(
                        name: "FK_CompanyStockExchange_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyStockExchange_StockExchanges_StockExchangeCode",
                        column: x => x.StockExchangeCode,
                        principalTable: "StockExchanges",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyStockExchange_StockExchangeCode",
                table: "CompanyStockExchange",
                column: "StockExchangeCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyStockExchange");
        }
    }
}
