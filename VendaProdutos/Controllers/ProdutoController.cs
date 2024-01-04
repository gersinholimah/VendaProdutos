using Microsoft.AspNetCore.Mvc;
using VendaProdutos.Models;
using VendaProdutos.Repositories.Interfaces;
using VendaProdutos.ViewModel;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Drawing.Imaging;

namespace VendaProdutos.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IActionResult List(string categoria, [FromForm] string postSuperior,
           [FromForm] string metaDescricao,
          [FromForm] string metaTitle,
           [FromForm] string metaImage,
           [FromForm] string urlAmigavel
            )
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
                //if(string.Equals("Cesta1", categoria, StringComparison.OrdinalIgnoreCase))
                //    {
                //    produtos = _produtoRepository.Produtos
                //            .Where(p => p.Categoria.CategoriaNome
                //            .Equals("Cesta1"))
                //            .OrderBy(p => p.Nome);
                //        }
                //else
                //{
                //    produtos = _produtoRepository.Produtos
                //               .Where(p => p.Categoria.CategoriaNome
                //               .Equals("Festa1"))
                //               .OrderBy(p => p.Nome);
                //}

                produtos = _produtoRepository.Produtos
                    .Where(p => p.Categoria.CategoriaNome.Equals(categoria))
                    .OrderBy(c => c.Nome);
                categoriaAtual = categoria;
                ViewBag.CategoriaAtual = categoriaAtual;
                ViewBag.PostSuperior = postSuperior;
                ViewBag.MetaDescricao = metaDescricao;
                ViewBag.MetaDescricao = metaDescricao;
                ViewBag.MetaTitle = metaTitle;
                ViewBag.MetaImage = metaImage;
                ViewBag.UrlAmigavel = urlAmigavel;
            }
            var produtosListViewModel = new ProdutoListViewModel
            {
                Produtos = produtos,
              

            };
            return View(produtosListViewModel);
        }
        public IActionResult Details(int produtoId) 
        {
            var produto = _produtoRepository.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);
            return View(produto);
                }
        public ViewResult Search(string searchString)
        {
            IEnumerable<Produto> produtos;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                produtos = _produtoRepository.Produtos.OrderBy(p => p.ProdutoId);
                categoriaAtual = "Todos os Produtos";
            }
            else
            {
                produtos = _produtoRepository.Produtos
                          .Where(p => p.Nome.ToLower().Contains(searchString.ToLower()));

                if (produtos.Any())
                    categoriaAtual = "Produtos";
                else
                    categoriaAtual = "Nenhum produto foi encontrado";
            }

            return View("~/Views/Produto/List.cshtml", new ProdutoListViewModel
            {
                Produtos = produtos,
                CategoriaAtual = categoriaAtual
            });
        }
    }
}
