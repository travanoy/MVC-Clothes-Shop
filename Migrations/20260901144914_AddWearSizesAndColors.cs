using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkerHub.Migrations
{
    /// <inheritdoc />
    public partial class AddWearSizesAndColors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "WearColorId",
                table: "OrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WearSizeId",
                table: "OrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WearColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HexCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WearColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WearSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WearSizes", x => x.Id);
                });

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
                table: "WearColors",
                columns: new[] { "Id", "HexCode", "Name" },
                values: new object[,]
                {
                    { 1, "#000000", "Black" },
                    { 2, "#FFFFFF", "White" },
                    { 3, "#808080", "Gray" },
                    { 4, "#000080", "Navy" },
                    { 5, "#1E3A5F", "Dark Blue" },
                    { 6, "#708238", "Olive" },
                    { 7, "#DC143C", "Red" },
                    { 8, "#F5F5DC", "Beige" }
                });

            migrationBuilder.InsertData(
                table: "WearSizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "S" },
                    { 2, "M" },
                    { 3, "L" },
                    { 4, "XL" },
                    { 5, "30" },
                    { 6, "32" },
                    { 7, "34" },
                    { 8, "36" }
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
                name: "IX_OrderItems_WearColorId",
                table: "OrderItems",
                column: "WearColorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_WearSizeId",
                table: "OrderItems",
                column: "WearSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWearColors_WearColorId",
                table: "ProductWearColors",
                column: "WearColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWearSizes_WearSizeId",
                table: "ProductWearSizes",
                column: "WearSizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_WearColors_WearColorId",
                table: "OrderItems",
                column: "WearColorId",
                principalTable: "WearColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_WearSizes_WearSizeId",
                table: "OrderItems",
                column: "WearSizeId",
                principalTable: "WearSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_WearColors_WearColorId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_WearSizes_WearSizeId",
                table: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductWearColors");

            migrationBuilder.DropTable(
                name: "ProductWearSizes");

            migrationBuilder.DropTable(
                name: "WearColors");

            migrationBuilder.DropTable(
                name: "WearSizes");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_WearColorId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_WearSizeId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "WearColorId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "WearSizeId",
                table: "OrderItems");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Size",
                value: "M");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Size",
                value: "L");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Size",
                value: "32");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Size",
                value: "34");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Size",
                value: "M");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Size",
                value: "M");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Size",
                value: "32");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Size",
                value: "L");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Size",
                value: "L");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "Size",
                value: "34");
        }
    }
}
