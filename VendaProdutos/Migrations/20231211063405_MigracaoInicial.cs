using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendaProdutos.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaNome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(38)", maxLength: 38, nullable: false),
                    ImagemDestaque = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DescricaoTagAlt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostSuperior = table.Column<string>(type: "nvarchar(max)", maxLength: 100000, nullable: false),
                    PostInferior = table.Column<string>(type: "nvarchar(max)", maxLength: 100000, nullable: false),
                    MetaDescricao = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    MetaImage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MetaTitle = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    UrlAmigavel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sku = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Altura = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Largura = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Profundidade = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Comprimento = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Peso = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    GaleriaImagemURL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DescricaoImgTagAlt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    DescricaoCurta = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DescricaoDetalhada = table.Column<string>(type: "nvarchar(max)", maxLength: 100000, nullable: false),
                    PostInferior = table.Column<string>(type: "nvarchar(max)", maxLength: 100000, nullable: false),
                    PrecoPromocional = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Parcela = table.Column<int>(type: "int", nullable: false),
                    MetaDescricao = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    MetaImage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MetaTitle = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    UrlAmigavel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImagemUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImagemThumbnailUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsProdutoEmAlta = table.Column<bool>(type: "bit", nullable: false),
                    Esgotado = table.Column<bool>(type: "bit", nullable: false),
                    TaxaDeEntrega = table.Column<int>(type: "int", nullable: false),
                    SobEncomenda = table.Column<bool>(type: "bit", nullable: false),
                    QuantidadeDeItem = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
