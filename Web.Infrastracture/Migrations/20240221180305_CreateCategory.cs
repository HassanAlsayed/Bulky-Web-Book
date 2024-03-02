using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class CreateCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44407b16-bb4f-472a-8cf8-d51cbdd44433"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("638dc93d-3553-4d3f-8285-5e4bd40a642c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fe373f27-6880-43ac-a4b1-4de6defa52f1"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { new Guid("44407b16-bb4f-472a-8cf8-d51cbdd44433"), "Billy Spark", new Guid("1a191997-feaa-4837-8b62-359349000f91"), "des", "SWD9999001", null, 99.0, 90.0, 80.0, 85.0, "Fortune of Time" },
                    { new Guid("638dc93d-3553-4d3f-8285-5e4bd40a642c"), "Abby Mucles", new Guid("2d6f9b00-6e59-461b-99be-c92701fbb6c8"), "des", "WS3333333301", null, 70.0, 65.0, 55.0, 60.0, "Cotton Candy" },
                    { new Guid("fe373f27-6880-43ac-a4b1-4de6defa52f1"), "Ron Parker", new Guid("ff718b93-f78c-477c-abd6-56d7d5a2a8d7"), "des", "SOTJ1111111101", null, 30.0, 27.0, 20.0, 25.0, "Rock in the Ocean" }
                });
        }
    }
}
