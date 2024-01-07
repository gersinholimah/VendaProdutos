using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendaProdutos.Migrations
{
    /// <inheritdoc />
    public partial class SubstituiPropriedadeListarCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ListarCategoria",
                table: "Categorias",
                newName: "EsconderCategoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EsconderCategoria",
                table: "Categorias",
                newName: "ListarCategoria");
        }
    }
}
