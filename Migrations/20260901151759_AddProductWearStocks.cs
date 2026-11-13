using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkerHub.Migrations
{
    /// <inheritdoc />
    public partial class AddProductWearStocks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductWearColors");

            migrationBuilder.DropTable(
                name: "ProductWearSizes");

            migrationBuilder.CreateTable(
                name: "ProductWearStocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    WearSizeId = table.Column<int>(type: "int", nullable: false),
                    WearColorId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWearStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductWearStocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductWearStocks_Products_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductWearStocks_WearColors_WearColorId",
                        column: x => x.WearColorId,
                        principalTable: "WearColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductWearStocks_WearSizes_WearSizeId",
                        column: x => x.WearSizeId,
                        principalTable: "WearSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductWearStocks",
                columns: new[] { "Id", "ProductId", "ProductId1", "Quantity", "WearColorId", "WearSizeId" },
                values: new object[,]
                {
                    { -61, 10, null, 10, 4, 8 },
                    { -60, 10, null, 10, 1, 8 },
                    { -59, 10, null, 10, 4, 7 },
                    { -58, 10, null, 10, 1, 7 },
                    { -57, 10, null, 10, 4, 6 },
                    { -56, 10, null, 10, 1, 6 },
                    { -55, 9, null, 10, 3, 4 },
                    { -54, 9, null, 10, 2, 4 },
                    { -53, 9, null, 10, 3, 3 },
                    { -52, 9, null, 10, 2, 3 },
                    { -51, 9, null, 10, 3, 2 },
                    { -50, 9, null, 10, 2, 2 },
                    { -49, 8, null, 10, 5, 4 },
                    { -48, 8, null, 10, 5, 3 },
                    { -47, 8, null, 10, 5, 2 },
                    { -46, 7, null, 10, 5, 7 },
                    { -45, 7, null, 10, 5, 6 },
                    { -44, 7, null, 10, 5, 5 },
                    { -43, 6, null, 10, 1, 3 },
                    { -42, 6, null, 10, 1, 2 },
                    { -41, 6, null, 10, 1, 1 },
                    { -40, 5, null, 3, 6, 3 },
                    { -39, 5, null, 4, 1, 3 },
                    { -38, 5, null, 4, 6, 2 },
                    { -37, 5, null, 2, 1, 2 },
                    { -36, 4, null, 8, 6, 8 },
                    { -35, 4, null, 8, 5, 8 },
                    { -34, 4, null, 8, 6, 7 },
                    { -33, 4, null, 8, 5, 7 },
                    { -32, 4, null, 8, 6, 6 },
                    { -31, 4, null, 8, 5, 6 },
                    { -30, 3, null, 5, 5, 7 },
                    { -29, 3, null, 5, 1, 7 },
                    { -28, 3, null, 5, 5, 6 },
                    { -27, 3, null, 5, 1, 6 },
                    { -26, 3, null, 5, 5, 5 },
                    { -25, 3, null, 2, 1, 5 },
                    { -24, 2, null, 10, 4, 4 },
                    { -23, 2, null, 10, 2, 4 },
                    { -22, 2, null, 10, 1, 4 },
                    { -21, 2, null, 10, 4, 3 },
                    { -20, 2, null, 10, 2, 3 },
                    { -19, 2, null, 10, 1, 3 },
                    { -18, 2, null, 10, 4, 2 },
                    { -17, 2, null, 10, 2, 2 },
                    { -16, 2, null, 10, 1, 2 },
                    { -15, 2, null, 10, 4, 1 },
                    { -14, 2, null, 10, 2, 1 },
                    { -13, 2, null, 10, 1, 1 },
                    { -12, 1, null, 10, 5, 4 },
                    { -11, 1, null, 10, 4, 4 },
                    { -10, 1, null, 10, 2, 4 },
                    { -9, 1, null, 10, 5, 3 },
                    { -8, 1, null, 10, 4, 3 },
                    { -7, 1, null, 10, 2, 3 },
                    { -6, 1, null, 10, 5, 2 },
                    { -5, 1, null, 10, 4, 2 },
                    { -4, 1, null, 10, 2, 2 },
                    { -3, 1, null, 10, 5, 1 },
                    { -2, 1, null, 10, 4, 1 },
                    { -1, 1, null, 10, 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductWearStocks_ProductId_WearSizeId_WearColorId",
                table: "ProductWearStocks",
                columns: new[] { "ProductId", "WearSizeId", "WearColorId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductWearStocks_ProductId1",
                table: "ProductWearStocks",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWearStocks_WearColorId",
                table: "ProductWearStocks",
                column: "WearColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWearStocks_WearSizeId",
                table: "ProductWearStocks",
                column: "WearSizeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductWearStocks");

            migrationBuilder.CreateTable(
                name: "ProductWearColors",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    WearColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWearColors", x => new { x.ProductId, x.WearColorId });
                    table.ForeignKey(
                        name: "FK_ProductWearColors_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductWearColors_WearColors_WearColorId",
                        column: x => x.WearColorId,
                        principalTable: "WearColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductWearSizes",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    WearSizeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWearSizes", x => new { x.ProductId, x.WearSizeId });
                    table.ForeignKey(
                        name: "FK_ProductWearSizes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductWearSizes_WearSizes_WearSizeId",
                        column: x => x.WearSizeId,
                        principalTable: "WearSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductWearColors",
                columns: new[] { "ProductId", "WearColorId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 4 },
                    { 3, 1 },
                    { 3, 5 },
                    { 4, 5 },
                    { 4, 6 },
                    { 5, 1 },
                    { 5, 6 },
                    { 6, 1 },
                    { 7, 5 },
                    { 8, 5 },
                    { 9, 2 },
                    { 9, 3 },
                    { 10, 1 },
                    { 10, 4 }
                });

            migrationBuilder.InsertData(
                table: "ProductWearSizes",
                columns: new[] { "ProductId", "WearSizeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 3, 7 },
                    { 4, 6 },
                    { 4, 7 },
                    { 4, 8 },
                    { 5, 2 },
                    { 5, 3 },
                    { 6, 1 },
                    { 6, 2 },
                    { 6, 3 },
                    { 7, 5 },
                    { 7, 6 },
                    { 7, 7 },
                    { 8, 2 },
                    { 8, 3 },
                    { 8, 4 },
                    { 9, 2 },
                    { 9, 3 },
                    { 9, 4 },
                    { 10, 6 },
                    { 10, 7 },
                    { 10, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductWearColors_WearColorId",
                table: "ProductWearColors",
                column: "WearColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWearSizes_WearSizeId",
                table: "ProductWearSizes",
                column: "WearSizeId");
        }
    }
}
