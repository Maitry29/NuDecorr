﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NuDecorr.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductID);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Table" },
                    { 2, 2, "Chair" },
                    { 3, 1, "Sofa" },
                    { 4, 3, "Lamp" },
                    { 5, 1, "Bed" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductID", "Description", "ImageURL", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "A high-quality wooden dining table with a modern design.", "https://example.com/images/dining-table.jpg", 19999.99m, "Wooden Dining Table" },
                    { 2, "A comfortable and elegant sofa set for your living room.", "https://example.com/images/sofa-set.jpg", 29999.99m, "Luxury Sofa Set" },
                    { 3, "Ergonomic office chair with adjustable height and back support.", "https://example.com/images/office-chair.jpg", 7999.99m, "Office Chair" },
                    { 4, "Ergonomic lamp with adjustable height.", "https://example.com/images/office-chair.jpg", 7999.99m, "Lamp" },
                    { 5, "Comfortable bed with back support.", "https://example.com/images/office-chair.jpg", 7999.99m, "Bed" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
