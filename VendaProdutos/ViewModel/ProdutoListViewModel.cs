using VendaProdutos.Models;

namespace VendaProdutos.ViewModel
{
    public class ProdutoListViewModel
    {
        public IEnumerable<Produto> Produtos { get; set; }
        public string CategoriaAtual { get; set; }
        public string PostSuperior { get; set; }

    }
}
