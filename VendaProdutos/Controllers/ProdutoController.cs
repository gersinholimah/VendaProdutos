using Microsoft.AspNetCore.Mvc;
using VendaProdutos.Models;
using VendaProdutos.Repositories.Interfaces;
using VendaProdutos.ViewModel;

namespace VendaProdutos.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Produto> produtos;
            string categoriaAtual = string.Empty;
           
            if(string.IsNullOrEmpty(categoria))
            {
                produtos = _produtoRepository.Produtos.OrderBy(p => p.ProdutoId);
                    categoriaAtual = "Todos os lanches";
            }
            else
            {
                if(string.Equals("Cesta1", categoria, StringComparison.OrdinalIgnoreCase))
                    {
                    produtos = _produtoRepository.Produtos
                            .Where(p => p.Categoria.CategoriaNome
                            .Equals("Cesta1"))
                            .OrderBy(p => p.Nome);
                        }
                else
                {
                    produtos = _produtoRepository.Produtos
                               .Where(p => p.Categoria.CategoriaNome
                               .Equals("Festa1"))
                               .OrderBy(p => p.Nome);
                }
               
                   
             }
            var produtosListViewModel = new ProdutoListViewModel
            {
                Produtos = produtos,
                CategoriaAtual = categoriaAtual
            };
            return View(produtosListViewModel);
        }
    }
}
