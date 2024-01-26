using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendaProdutos.Migrations
{
    /// <inheritdoc />
    public partial class RetiraCedilhaDeEnderecoNaoEncontrado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EndereçoNaoEncontrado",
                table: "Pedidos",
                newName: "EnderecoNaoEncontrado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EnderecoNaoEncontrado",
                table: "Pedidos",
                newName: "EndereçoNaoEncontrado");
        }
    }
}
