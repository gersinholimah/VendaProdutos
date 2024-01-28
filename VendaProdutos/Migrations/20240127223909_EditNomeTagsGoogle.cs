using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendaProdutos.Migrations
{
    /// <inheritdoc />
    public partial class EditNomeTagsGoogle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "google_product_category",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "product_type",
                table: "Produtos");

            migrationBuilder.AddColumn<string>(
                name: "GoogleProductCategory",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductType",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoogleProductCategory",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "Produtos");

            migrationBuilder.AddColumn<string>(
                name: "google_product_category",
                table: "Produtos",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "product_type",
                table: "Produtos",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");
        }
    }
}
