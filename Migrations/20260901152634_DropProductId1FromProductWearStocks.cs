using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkerHub.Migrations
{
    /// <inheritdoc />
    public partial class DropProductId1FromProductWearStocks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductWearStocks_Products_ProductId1",
                table: "ProductWearStocks");

            migrationBuilder.DropIndex(
                name: "IX_ProductWearStocks_ProductId1",
                table: "ProductWearStocks");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "ProductWearStocks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "ProductWearStocks",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -61,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -60,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -59,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -58,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -57,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -56,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -55,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -54,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -53,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -52,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -51,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -50,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -49,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -48,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -47,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -46,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -45,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -44,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -43,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -42,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -41,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -40,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -39,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -38,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -37,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -36,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -35,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -34,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -33,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -32,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -31,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -30,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -29,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -28,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -27,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -26,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -25,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -24,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -23,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -22,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -21,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -20,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -19,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -18,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -17,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -16,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -15,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -14,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -13,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -12,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -11,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -10,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -9,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -8,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -7,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -6,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -5,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -4,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -3,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -2,
                column: "ProductId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductWearStocks",
                keyColumn: "Id",
                keyValue: -1,
                column: "ProductId1",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_ProductWearStocks_ProductId1",
                table: "ProductWearStocks",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductWearStocks_Products_ProductId1",
                table: "ProductWearStocks",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
