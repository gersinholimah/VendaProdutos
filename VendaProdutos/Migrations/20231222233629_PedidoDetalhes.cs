using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendaProdutos.Migrations
{
    /// <inheritdoc />
    public partial class PedidoDetalhes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeComprador = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApelidoComprador = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CPFComprador = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    WhatsappComprador = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NomeRecebedor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ApelidoRecebedor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BairroRecebedor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RuaRecebedor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ComplementoRecebedor = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NumeroCasaRecebedor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WhatsappRecebedor = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DataDeEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraDaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Cartinha = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    TotalPedido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalItensPedido = table.Column<int>(type: "int", nullable: false),
                    PedidoEnviado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PedidoEntregueEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidoId);
                });

            migrationBuilder.CreateTable(
                name: "PedidosDetalhe",
                columns: table => new
                {
                    PedidoDetalheId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosDetalhe", x => x.PedidoDetalheId);
                    table.ForeignKey(
                        name: "FK_PedidosDetalhe_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidosDetalhe_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidosDetalhe_PedidoId",
                table: "PedidosDetalhe",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosDetalhe_ProdutoId",
                table: "PedidosDetalhe",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidosDetalhe");

            migrationBuilder.DropTable(
                name: "Pedidos");
        }
    }
}
