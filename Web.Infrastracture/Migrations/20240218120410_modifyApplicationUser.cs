using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class modifyApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a984fcf0-38a1-4e82-b27c-fb39e0c93f30"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c480bf6d-a28b-4565-b162-3e92eccd04b6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c9bba0fe-a994-4fc1-9890-515e95a7e281"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { new Guid("14d0d3ab-3c65-480e-b112-a5d3a1f80bd6"), "Billy Spark", "des", "SWD9999001", 99.0, 90.0, 80.0, 85.0, "Fortune of Time" },
                    { new Guid("8316baff-b0a2-4d88-bf72-f07a6fc327ca"), "Abby Mucles", "des", "WS3333333301", 70.0, 65.0, 55.0, 60.0, "Cotton Candy" },
                    { new Guid("b2acc519-abde-4d34-ac8b-ab224f11ba63"), "Ron Parker", "des", "SOTJ1111111101", 30.0, 27.0, 20.0, 25.0, "Rock in the Ocean" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("14d0d3ab-3c65-480e-b112-a5d3a1f80bd6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8316baff-b0a2-4d88-bf72-f07a6fc327ca"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b2acc519-abde-4d34-ac8b-ab224f11ba63"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { new Guid("a984fcf0-38a1-4e82-b27c-fb39e0c93f30"), "Ron Parker", "des", "SOTJ1111111101", 30.0, 27.0, 20.0, 25.0, "Rock in the Ocean" },
                    { new Guid("c480bf6d-a28b-4565-b162-3e92eccd04b6"), "Abby Mucles", "des", "WS3333333301", 70.0, 65.0, 55.0, 60.0, "Cotton Candy" },
                    { new Guid("c9bba0fe-a994-4fc1-9890-515e95a7e281"), "Billy Spark", "des", "SWD9999001", 99.0, 90.0, 80.0, 85.0, "Fortune of Time" }
                });
        }
    }
}
