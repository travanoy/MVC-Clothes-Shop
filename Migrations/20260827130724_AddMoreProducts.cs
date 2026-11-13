using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkerHub.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1548036328-c9fa89d128fa?w=600");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1562157873-818bc0726f68?w=600");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1611312449408-fcece27cdbb7?w=600");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1544441893-675973e31985?w=600");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1598033129183-c4f50c736f10?w=600");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsAvailable", "Name", "Price", "Size", "StockQuantity" },
                values: new object[,]
                {
                    { 6, 1, "Minimalist black tee with a clean, tailored fit.", "https://images.unsplash.com/photo-1583864697784-a0efc8379f70?w=600", true, "Essential Black Tee", 22.00m, "M", 45 },
                    { 7, 2, "Modern tapered denim with a deep dark wash.", "https://images.unsplash.com/photo-1620121692029-d088224ddc74?w=600", true, "Tapered Dark Jeans", 60.00m, "32", 28 },
                    { 8, 3, "Timeless denim trucker jacket for any season.", "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=600", true, "Minimal Denim Jacket", 75.00m, "L", 18 },
                    { 9, 1, "Crisp white cotton tee, soft and long-lasting.", "https://images.unsplash.com/photo-1593079831268-3381b0db4a77?w=600", true, "Classic White Tee", 19.00m, "L", 55 },
                    { 10, 2, "Slim-fit black jeans with a subtle fade.", "https://images.unsplash.com/photo-1542125387-c71274d94f0a?w=600", true, "Slim Black Jeans", 58.00m, "34", 22 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1576566588028-4147f3842f27?w=600");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1503341504253-dff4815485f1?w=600");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1541099649105-f69ad21f3246?w=600");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1576995853123-5a10305d93c0?w=600");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1604644401890-0bd678c83703?w=600");
        }
    }
}
