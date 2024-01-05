using Microsoft.AspNetCore.Mvc;
using VendaProdutos.Models;
using VendaProdutos.Repositories.Interfaces;
using VendaProdutos.ViewModel;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Drawing.Imaging;
using VendaProdutos.Context;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VendaProdutos.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly IProdutoRepository _produtoRepository;
        private readonly AppDbContext _context;

        public ProdutoController(IProdutoRepository produtoRepository, AppDbContext context)
        {
            _produtoRepository = produtoRepository;
            _context = context;

        }

        public IActionResult List(string categoria, [FromForm] string postSuperior,
           [FromForm] string metaDescricao,
          [FromForm] string metaTitle,
           [FromForm] string metaImage 
 
            )
        {
            IEnumerable<Produto> produtos;
            IEnumerable<Categoria> listaCategorias = _context.Categorias.Include(c => c.Produtos).ToList();
            string categoriaAtual = string.Empty;
            bool exibeCategoria = false;
            string pathProduto = "Produtos/";
            ViewBag.PathProduto = pathProduto;
            Categoria produtoAtual = null;

      

            if (string.IsNullOrEmpty(categoria))
            {
                produtos = _produtoRepository.Produtos.OrderBy(p => p.ProdutoId);
                categoriaAtual = "Categorias";
                exibeCategoria = true;
            }
            else
            {
              
                exibeCategoria = false;
                produtos = _produtoRepository.Produtos
                    .Where(p => p.Categoria.CategoriaNome.Equals(categoria))
                    .OrderBy(c => c.Nome);
                categoriaAtual = categoria; 
                ViewBag.CategoriaAtual = categoriaAtual;
                ViewBag.MetaDescricao = metaDescricao;
                 ViewBag.MetaTitle = metaTitle;
                ViewBag.MetaImage = metaImage;
            }

            var produtosListViewModel = new ProdutoListViewModel
            {
                Produtos = produtos,
                PostSuperior = postSuperior,
                CategoriaAtual = categoriaAtual,
                Categorias = listaCategorias,
                ExibeCategoria = exibeCategoria
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
