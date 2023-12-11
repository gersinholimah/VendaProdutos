using Microsoft.AspNetCore.Mvc;
using VendaProdutos.Repositories.Interfaces;

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
            var produtos = _produtoRepository.Produtos;
            return View(produtos);
        }
    }
}
