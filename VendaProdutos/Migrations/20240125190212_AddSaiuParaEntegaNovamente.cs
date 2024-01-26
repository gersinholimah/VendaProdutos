using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendaProdutos.Migrations
{
    /// <inheritdoc />
    public partial class AddSaiuParaEntegaNovamente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SaiuParaEntegaNovamente",
                table: "Pedidos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaiuParaEntegaNovamente",
                table: "Pedidos");
        }
    }
}
