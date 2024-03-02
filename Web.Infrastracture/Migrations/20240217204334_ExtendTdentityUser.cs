using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class ExtendTdentityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6ec6a1b8-6bac-4445-8f50-5ef48367e7a0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cd591c67-65d2-401b-adbf-c07fbd1ee368"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cfaabd2f-b82a-49c2-990d-79b568e45346"));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreeAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { new Guid("32b74a4b-c431-45dc-a9e7-07a65cf19163"), "Billy Spark", "des", "SWD9999001", 99.0, 90.0, 80.0, 85.0, "Fortune of Time" },
                    { new Guid("8695ff8d-d1b3-4094-8e03-8d0736aac2c7"), "Ron Parker", "des", "SOTJ1111111101", 30.0, 27.0, 20.0, 25.0, "Rock in the Ocean" },
                    { new Guid("beb994a7-32aa-47e1-9ef5-62775f2afb06"), "Abby Mucles", "des", "WS3333333301", 70.0, 65.0, 55.0, 60.0, "Cotton Candy" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("32b74a4b-c431-45dc-a9e7-07a65cf19163"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8695ff8d-d1b3-4094-8e03-8d0736aac2c7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("beb994a7-32aa-47e1-9ef5-62775f2afb06"));

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StreeAddress",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { new Guid("6ec6a1b8-6bac-4445-8f50-5ef48367e7a0"), "Abby Mucles", "des", "WS3333333301", 70.0, 65.0, 55.0, 60.0, "Cotton Candy" },
                    { new Guid("cd591c67-65d2-401b-adbf-c07fbd1ee368"), "Ron Parker", "des", "SOTJ1111111101", 30.0, 27.0, 20.0, 25.0, "Rock in the Ocean" },
                    { new Guid("cfaabd2f-b82a-49c2-990d-79b568e45346"), "Billy Spark", "des", "SWD9999001", 99.0, 90.0, 80.0, 85.0, "Fortune of Time" }
                });
        }
    }
}
