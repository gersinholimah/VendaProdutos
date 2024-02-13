using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendaProdutos.Migrations
{
    /// <inheritdoc />
    public partial class PopularCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao, ImagemDestaque, DescricaoTagAlt, PostSuperior, PostInferior, MetaDescricao, MetaImage, MetaTitle, UrlAmigavel)"
          + "VALUES('Cestas1', 'Cestas especiais', 'https://media.gazetadopovo.com.br/2023/06/12203829/cesta-de-cafe-da-manha.png', 'Cesta com muitos itens' ,'Desperte sabores e emoções com nossas cestas de café da manhã. Cada seleção é uma jornada gastronômica, repleta de carinho e delicadeza. Surpreenda quem você ama com o presente perfeito para iniciar o dia com alegria e sabor.,Celebre momentos únicos com presentes excepcionais. Surpreenda quem ama com nossas cestas exclusivas e deliciosas. Descubra o prazer de presentear com classe e sabor', 'Em Feira de Santana, Bahia, cada cesta é um pedaço de carinho local. Das delícias típicas às surpresas personalizadas, nossas cestas são um convite à celebração. Descubra o encanto da tradição em cada entrega, tornando momentos especiais ainda mais inesquecíveis. Presenteie com o sabor autêntico de Feira de Santana!', 'Surpreenda com cestas locais repletas de delícias autênticas. Presentes únicos que celebram o sabor de Feira de Santana!', 'https://media.gazetadopovo.com.br/2023/06/12203829/cesta-de-cafe-da-manha.png', 'Presentes e Sabores: Cestas Únicas de Feira de Santana, Bahia', 'cestas-teste')"
          );

            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao, ImagemDestaque, DescricaoTagAlt, PostSuperior, PostInferior, MetaDescricao, MetaImage, MetaTitle, UrlAmigavel)"
            + "VALUES('Festacaixa1' ,'Festa na caixa especiais' ,'https://cdn.awsli.com.br/300x300/1763/1763247/produto/117186187/1099427a9d.jpg' ,'Festa na caixa com muitos itens' ,'Desperte sabores e emoções com nossas Festa na caixa. Cada seleção é uma jornada gastronômica, repleta de carinho e delicadeza. Surpreenda quem você ama com o presente perfeito para iniciar o dia com alegria e sabor.,Celebre momentos únicos com presentes excepcionais. Surpreenda quem ama com nossas cestas exclusivas e deliciosas. Descubra o prazer de presentear com classe e sabor' ,'Em Feira de Santana, Bahia, cada Festa na caixa é um pedaço de carinho local. Das delícias típicas às surpresas personalizadas, nossas cestas são um convite à celebração. Descubra o encanto da tradição em cada entrega, tornando momentos especiais ainda mais inesquecíveis. Presenteie com o sabor autêntico de Feira de Santana!' ,'Surpreenda com cestas locais repletas de delícias autênticas. Presentes únicos que celebram o sabor de Feira de Santana!' ,'https://cdn.awsli.com.br/300x300/1763/1763247/produto/117186187/1099427a9d.jpg' ,'Presentes: Festa na caixa exclusiva de Feira de Santana, Bahia' ,'festa-na-caixa-teste')"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
