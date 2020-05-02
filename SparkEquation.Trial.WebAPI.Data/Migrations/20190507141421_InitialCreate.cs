using Microsoft.EntityFrameworkCore.Migrations;

namespace SparkEquation.Trial.WebAPI.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    BrandId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProducts",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProducts", x => new { x.CategoryId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CategoryProducts_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProducts_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[] { 1, "USA", "Pepsi" });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[] { 2, "USA", "Coca Cola" });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[] { 3, "USA", "Bud" });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[] { 4, "France", "Bordeaux" });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[] { 5, "Russia", "Essentuki" });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[] { 6, "Russia", "Lada" });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[] { 7, "USA", "Chevrolet" });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[] { 8, "Japan", "Toyota" });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[] { 9, "Japan", "Nissan" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Drinks" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Alcohol" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Sparkling" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Cars" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "4x4" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 8, 1, "Pepsi", 4.0 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 27, 8, "Prius", 4.0 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 26, 8, "Land Cruiser", 4.9000000000000004 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 25, 7, "Corvette", 4.9000000000000004 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 24, 7, "Camaro", 4.9000000000000004 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 23, 7, "Tahoe", 4.2000000000000002 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 22, 6, "Priora", 3.2000000000000002 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 21, 6, "Taiga", 3.7999999999999998 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 20, 6, "Granta", 3.2000000000000002 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 19, 6, "Kalina", 3.0 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 18, 6, "Oka", 1.0 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 17, 6, "1600", 2.0 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 16, 6, "1500", 1.8 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 28, 9, "Maxima", 4.0 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 15, 6, "1200/1300", 1.5 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 4, 5, "Essentuki 17", 4.5 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 3, 5, "Essentuki 4", 4.5 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 2, 4, "J.P. Chenet Pays D'Oc Cabernet - Syrah", 4.9000000000000004 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 1, 4, "La Vieille Ferme Rouge", 5.0 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 10, 3, "Budweiser 66", 4.0 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 9, 3, "Budweiser", 4.0 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 13, 2, "Zico", 4.5999999999999996 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 12, 2, "Surge", 3.6000000000000001 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 11, 2, "Simply", 3.0 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 7, 2, "Sprite", 4.0 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 6, 2, "Coca Cola", 4.0 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 5, 2, "Fanta", 4.0 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 14, 6, "Niva", 3.5 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "Name", "Rating" },
                values: new object[] { 29, 9, "Cube", 4.5 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 1, 8 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 3, 4 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 4, 14 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 5, 14 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 4, 15 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 4, 16 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 4, 17 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 4, 18 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 4, 19 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 4, 20 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 4, 21 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 5, 21 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 4, 22 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 4, 23 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 5, 23 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 4, 24 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 4, 25 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 4, 26 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 5, 26 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 4, 27 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 3, 8 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 1, 5 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 3, 5 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 1, 6 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 3, 6 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 1, 7 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 3, 7 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 1, 11 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 1, 12 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 3, 12 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 1, 13 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 1, 9 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 2, 9 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 3, 9 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 1, 10 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 2, 10 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 3, 10 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 4, 28 });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProducts_ProductId",
                table: "CategoryProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandId",
                table: "Product",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProducts");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Brand");
        }
    }
}
