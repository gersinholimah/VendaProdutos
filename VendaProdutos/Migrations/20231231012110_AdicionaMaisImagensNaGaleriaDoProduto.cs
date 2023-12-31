using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendaProdutos.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaMaisImagensNaGaleriaDoProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagem2CarolselURL",
                table: "Produtos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imagem3CarolselURL",
                table: "Produtos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imagem4CarolselURL",
                table: "Produtos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem2CarolselURL",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Imagem3CarolselURL",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Imagem4CarolselURL",
                table: "Produtos");
        }
    }
}
