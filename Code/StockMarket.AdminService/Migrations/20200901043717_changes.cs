using Microsoft.EntityFrameworkCore.Migrations;

namespace StockMarket.AdminService.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_StockExchanges_StockExchangeId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_IPODetails_StockExchanges_StockExchangeId",
                table: "IPODetails");

            migrationBuilder.DropForeignKey(
                name: "FK_StockPrices_Companies_CompanyId",
                table: "StockPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_StockPrices_StockExchanges_StockExchangeId1",
                table: "StockPrices");

            migrationBuilder.DropIndex(
                name: "IX_StockPrices_StockExchangeId1",
                table: "StockPrices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockExchanges",
                table: "StockExchanges");

            migrationBuilder.DropIndex(
                name: "IX_IPODetails_StockExchangeId",
                table: "IPODetails");

            migrationBuilder.DropIndex(
                name: "IX_Companies_StockExchangeId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CompanyCodeId",
                table: "StockPrices");

            migrationBuilder.DropColumn(
                name: "StockExchangeId1",
                table: "StockPrices");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StockExchanges");

            migrationBuilder.DropColumn(
                name: "StockExchangeId",
                table: "Companies");

            migrationBuilder.AlterColumn<int>(
                name: "StockExchangeId",
                table: "StockPrices",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "StockPrices",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StockExchangeCode",
                table: "StockPrices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "StockExchanges",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StockExchangeCode",
                table: "IPODetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StockExchangeCode",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockExchanges",
                table: "StockExchanges",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_StockPrices_StockExchangeCode",
                table: "StockPrices",
                column: "StockExchangeCode");

            migrationBuilder.CreateIndex(
                name: "IX_IPODetails_StockExchangeCode",
                table: "IPODetails",
                column: "StockExchangeCode",
                unique: true,
                filter: "[StockExchangeCode] IS NOT NULL");

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

            migrationBuilder.AddForeignKey(
                name: "FK_IPODetails_StockExchanges_StockExchangeCode",
                table: "IPODetails",
                column: "StockExchangeCode",
                principalTable: "StockExchanges",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockPrices_Companies_CompanyId",
                table: "StockPrices",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockPrices_StockExchanges_StockExchangeCode",
                table: "StockPrices",
                column: "StockExchangeCode",
                principalTable: "StockExchanges",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_StockExchanges_StockExchangeCode",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_IPODetails_StockExchanges_StockExchangeCode",
                table: "IPODetails");

            migrationBuilder.DropForeignKey(
                name: "FK_StockPrices_Companies_CompanyId",
                table: "StockPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_StockPrices_StockExchanges_StockExchangeCode",
                table: "StockPrices");

            migrationBuilder.DropIndex(
                name: "IX_StockPrices_StockExchangeCode",
                table: "StockPrices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockExchanges",
                table: "StockExchanges");

            migrationBuilder.DropIndex(
                name: "IX_IPODetails_StockExchangeCode",
                table: "IPODetails");

            migrationBuilder.DropIndex(
                name: "IX_Companies_StockExchangeCode",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "StockExchangeCode",
                table: "StockPrices");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "StockExchanges");

            migrationBuilder.DropColumn(
                name: "StockExchangeCode",
                table: "IPODetails");

            migrationBuilder.DropColumn(
                name: "StockExchangeCode",
                table: "Companies");

            migrationBuilder.AlterColumn<string>(
                name: "StockExchangeId",
                table: "StockPrices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "StockPrices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CompanyCodeId",
                table: "StockPrices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockExchangeId1",
                table: "StockPrices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StockExchanges",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "StockExchangeId",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockExchanges",
                table: "StockExchanges",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StockPrices_StockExchangeId1",
                table: "StockPrices",
                column: "StockExchangeId1");

            migrationBuilder.CreateIndex(
                name: "IX_IPODetails_StockExchangeId",
                table: "IPODetails",
                column: "StockExchangeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_StockExchangeId",
                table: "Companies",
                column: "StockExchangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_StockExchanges_StockExchangeId",
                table: "Companies",
                column: "StockExchangeId",
                principalTable: "StockExchanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IPODetails_StockExchanges_StockExchangeId",
                table: "IPODetails",
                column: "StockExchangeId",
                principalTable: "StockExchanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockPrices_Companies_CompanyId",
                table: "StockPrices",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockPrices_StockExchanges_StockExchangeId1",
                table: "StockPrices",
                column: "StockExchangeId1",
                principalTable: "StockExchanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
