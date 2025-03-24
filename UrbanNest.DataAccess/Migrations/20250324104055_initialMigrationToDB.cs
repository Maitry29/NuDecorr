using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UrbanNest.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initialMigrationToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_products_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "ID", "DisplayOrder", "Name" },
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
                columns: new[] { "ID", "CategoryId", "Description", "ImageURL", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, "A high-quality wooden dining table with a modern design.", "/images/products/Table.jpg", 19999.99m, "Wooden Dining Table" },
                    { 2, 2, "A comfortable and elegant sofa set for your living room.", "/images/products/Sofa.jpg", 29999.99m, "Luxury Sofa Set" },
                    { 3, 3, "Ergonomic office chair with adjustable height and back support.", "/images/products/Chair.jpg", 7999.99m, "Office Chair" },
                    { 4, 4, "Ergonomic lamp with adjustable height.", "/images/products/Lamp.jpg", 7999.99m, "Lamp" },
                    { 5, 3, "Comfortable bed with back support.", "/images/products/Bed.jpg", 7999.99m, "Bed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryId",
                table: "products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
