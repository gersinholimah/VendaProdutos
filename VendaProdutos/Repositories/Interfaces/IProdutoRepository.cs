using VendaProdutos.Models;

namespace VendaProdutos.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> Produtos { get; }
        IEnumerable<Produto> ProdutosEmAlta { get; }
        Produto GetProdutoById(int produtoId);

    }
}
