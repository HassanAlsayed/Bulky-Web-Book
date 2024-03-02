using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class createProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6831fd98-7563-4b90-82cd-139708f5f552"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("80e636e5-1ea8-401a-82ea-f258310bcd61"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a13f4b6e-4fcd-4363-a792-294bcad9da5f"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { new Guid("37d8db0d-5047-4d3b-9adb-4c607154e4f9"), "Ron Parker", new Guid("ff718b93-f78c-477c-abd6-56d7d5a2a8d7"), "des", "SOTJ1111111101", null, 30.0, 27.0, 20.0, 25.0, "Rock in the Ocean" },
                    { new Guid("84abbab3-3347-4bf2-8339-b2c4f5f39175"), "Billy Spark", new Guid("1a191997-feaa-4837-8b62-359349000f91"), "des", "SWD9999001", null, 99.0, 90.0, 80.0, 85.0, "Fortune of Time" },
                    { new Guid("beb293c7-c521-4fc1-bef9-d3701cb03836"), "Abby Mucles", new Guid("2d6f9b00-6e59-461b-99be-c92701fbb6c8"), "des", "WS3333333301", null, 70.0, 65.0, 55.0, 60.0, "Cotton Candy" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("37d8db0d-5047-4d3b-9adb-4c607154e4f9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("84abbab3-3347-4bf2-8339-b2c4f5f39175"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("beb293c7-c521-4fc1-bef9-d3701cb03836"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { new Guid("6831fd98-7563-4b90-82cd-139708f5f552"), "Abby Mucles", new Guid("2d6f9b00-6e59-461b-99be-c92701fbb6c8"), "des", "WS3333333301", null, 70.0, 65.0, 55.0, 60.0, "Cotton Candy" },
                    { new Guid("80e636e5-1ea8-401a-82ea-f258310bcd61"), "Billy Spark", new Guid("1a191997-feaa-4837-8b62-359349000f91"), "des", "SWD9999001", null, 99.0, 90.0, 80.0, 85.0, "Fortune of Time" },
                    { new Guid("a13f4b6e-4fcd-4363-a792-294bcad9da5f"), "Ron Parker", new Guid("ff718b93-f78c-477c-abd6-56d7d5a2a8d7"), "des", "SOTJ1111111101", null, 30.0, 27.0, 20.0, 25.0, "Rock in the Ocean" }
                });
        }
    }
}
