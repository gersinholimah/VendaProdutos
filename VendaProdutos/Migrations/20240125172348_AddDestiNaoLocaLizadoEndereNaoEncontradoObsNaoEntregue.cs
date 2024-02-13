using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendaProdutos.Migrations
{
    /// <inheritdoc />
    public partial class AddDestiNaoLocaLizadoEndereNaoEncontradoObsNaoEntregue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DestinatarioNaoLocalizado",
                table: "Pedidos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EndereçoNaoEncontrado",
                table: "Pedidos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ObservacaoNaoEntregue",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DestinatarioNaoLocalizado",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "EndereçoNaoEncontrado",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ObservacaoNaoEntregue",
                table: "Pedidos");
        }
    }
}
