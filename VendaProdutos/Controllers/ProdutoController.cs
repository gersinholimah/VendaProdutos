using Microsoft.AspNetCore.Mvc;
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

        public IActionResult List()
        {

            //ViewData["data"] = DateTime.Now;
            var produtos = _produtoRepository.Produtos;
            //var totalProdutos = produtos.Count();
            //ViewBag.Produto = totalProdutos;

            //return View(produtos);

            var produtosListViewModel = new ProdutoListViewModel();
            produtosListViewModel.Produtos = _produtoRepository.Produtos;
            produtosListViewModel.CategoriaAtual = "Categoria Atual";

            return View(produtosListViewModel);
        }
    }
}
