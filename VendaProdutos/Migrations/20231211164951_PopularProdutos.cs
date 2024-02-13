using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendaProdutos.Migrations
{
    /// <inheritdoc />
    public partial class PopularProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Adicionar dados à tabela Produtos
            migrationBuilder.Sql("INSERT INTO Produtos (Sku, Altura, Largura, Profundidade, Comprimento, Peso, GaleriaImagemURL, DescricaoImgTagAlt, Nome, DescricaoCurta, DescricaoDetalhada, PostInferior, PrecoPromocional, Preco, Parcela, MetaDescricao, MetaImage, MetaTitle, UrlAmigavel, ImagemUrl, ImagemThumbnailUrl, IsProdutoEmAlta, Esgotado, TaxaDeEntrega, SobEncomenda, QuantidadeDeItem, CategoriaId) " +
                               "VALUES ('SKU001', 10.5, 5.5, 3.0, 15.0, 1.2, 'imagem1.jpg', 'Descrição da imagem', 'Produto1', 'Descrição curta do Produto1', 'Descrição detalhada do Produto1', 'Post inferior do Produto1', 9.99, 19.99, 3, 'Meta Descrição do Produto1', 'meta-imagem1.jpg', 'Meta Título do Produto1', 'url-amigavel-produto1', 'imagem1.jpg', 'thumbnail1.jpg', 1, 0, 5, 1, 100, 1)");

            migrationBuilder.Sql("INSERT INTO Produtos (Sku, Altura, Largura, Profundidade, Comprimento, Peso, GaleriaImagemURL, DescricaoImgTagAlt, Nome, DescricaoCurta, DescricaoDetalhada, PostInferior, PrecoPromocional, Preco, Parcela, MetaDescricao, MetaImage, MetaTitle, UrlAmigavel, ImagemUrl, ImagemThumbnailUrl, IsProdutoEmAlta, Esgotado, TaxaDeEntrega, SobEncomenda, QuantidadeDeItem, CategoriaId) " +
                               "VALUES ('SKU002', 12.0, 6.0, 4.0, 18.0, 1.5, 'imagem2.jpg', 'Descrição da imagem', 'Produto2', 'Descrição curta do Produto2', 'Descrição detalhada do Produto2', 'Post inferior do Produto2', 12.99, 24.99, 6, 'Meta Descrição do Produto2', 'meta-imagem2.jpg', 'Meta Título do Produto2', 'url-amigavel-produto2', 'imagem2.jpg', 'thumbnail2.jpg', 0, 0, 7, 0, 150, 2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FRON Produtos");
        }
    }
}
