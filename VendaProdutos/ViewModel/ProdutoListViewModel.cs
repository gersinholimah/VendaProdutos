using Microsoft.EntityFrameworkCore;
using VendaProdutos.Models;

namespace VendaProdutos.ViewModel
{
    public class ProdutoListViewModel
    {
        public IEnumerable<Produto> Produtos { get; set; }
        public IEnumerable<Categoria> Categorias { get; set; }
        public IEnumerable<Produto> OpcoesExtra { get; set; }

        public Produto Produto { get; set; }

        
        public string CategoriaAtual { get; set; }
        public string PostSuperior { get; set; }
        
          public string PostInferior { get; set; }

        public bool ExibeCategoria { get; set; }

        
    }
}
