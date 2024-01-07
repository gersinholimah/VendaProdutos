using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendaProdutos.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaPropriedadeListarCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ListarCategoria",
                table: "Categorias",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ListarCategoria",
                table: "Categorias");
        }
    }
}
