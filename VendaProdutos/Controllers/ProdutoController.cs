using Microsoft.AspNetCore.Mvc;
using VendaProdutos.Models;
using VendaProdutos.Repositories.Interfaces;
using VendaProdutos.ViewModel;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Drawing.Imaging;
using VendaProdutos.Context;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VendaProdutos.Repositories;

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

        //         [FromForm]
        //, string postSuperior
        //   [FromForm] string metaDescricao,
        //  [FromForm] string metaTitle,
        //   [FromForm] string metaImage,
        //  [FromForm] string postInferior

        public IActionResult List( string categoria, int categoriaid)
        {
            IEnumerable<Produto> produtos;
            IEnumerable<Categoria> listaCategorias = _context.Categorias.Include(c => c.Produtos).Where(c => !c.EsconderCategoria).ToList();
            string categoriaAtual = string.Empty;
            bool exibeCategoria = false;
            string pathProduto = "Produtos/";
            ViewBag.PathProduto = pathProduto;
            Categoria categoriaSelecionada = null;

            //Produto produtoAtivo = null;
            {
                categoriaSelecionada = _context.Categorias.Where(c => c.CategoriaId == categoriaid).FirstOrDefault();
            };
            string metaTitle = categoriaSelecionada?.MetaTitle ?? ""; ;
            string postSuperior = categoriaSelecionada?.PostSuperior ?? "";
            string metaDescricao = categoriaSelecionada?.MetaDescricao ?? "";
            string metaImage = categoriaSelecionada?.MetaImage ?? "";
            string postInferior = categoriaSelecionada?.PostInferior ?? "";
            string nomeCategoria = categoriaSelecionada?.CategoriaNome ?? "";
            //var listaDeProdutos = _context.Produtos;
            //IProdutoRepository produtoss =
            ViewBag.idDaCategoriaAtual = categoriaid;
            ViewBag.menuTodosProdutosAtivo = false;
            ViewBag.ProdutosCadastrados = _produtoRepository.Produtos;

            ViewBag.IndexarPagina = true;

            if (string.IsNullOrEmpty(nomeCategoria))
            {
                produtos = _produtoRepository.Produtos.OrderBy(p => p.ProdutoId);
                categoriaAtual = "Categorias";
                exibeCategoria = true;
                ViewBag.MetaTitle = "Cestas, festa na caixa e presentes em Feira de Santana: Entrega rápida e segura.";
                ViewBag.menuTodosProdutosAtivo = true;
            }
            else
            {
                     // Obtém a string da propriedade e substitui espaços por hifens
 
                 exibeCategoria = false;
                produtos = _produtoRepository.Produtos
                    .Where(p => p.Categoria.CategoriaNome.Equals(nomeCategoria))
                    .OrderBy(c => c.Nome);
                categoriaAtual = nomeCategoria; 
                ViewBag.CategoriaAtual = categoriaAtual;
                ViewBag.MetaDescricao = metaDescricao;
                 ViewBag.MetaTitle = nomeCategoria;
                ViewBag.MetaImage = metaImage;
            }

            var produtosListViewModel = new ProdutoListViewModel
            {
                Produtos = produtos,
                PostSuperior = postSuperior,
                PostInferior = postInferior,
                CategoriaAtual = categoriaAtual,
                Categorias = listaCategorias,
                ExibeCategoria = exibeCategoria,
            };
            return View(produtosListViewModel);
        }
        public IActionResult Details(string nome, int produtoId) 
        {

             IEnumerable<Produto> listaOpcoesExtra = _produtoRepository.Produtos.Where(c => c.OpcaoExtra).ToList();
            var produto = _produtoRepository.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);
            IEnumerable<Categoria> listaCategorias = _context.Categorias.Include(c => c.Produtos).Where(c => !c.EsconderCategoria).ToList();

            ViewBag.MetaTitle = produto.MetaTitle;
            ViewBag.MetaDescricao = produto.MetaDescricao;
            ViewBag.MetaImage = produto.ImagemUrl;

            ViewBag.ProdutosCadastrados = _produtoRepository.Produtos;
            ViewBag.IdDoDetalheDoProdutoAtivo = produtoId;

            ViewBag.IndexarPagina = true;

            // Adicione outros dados necessários ao ViewModel
            var produtosListViewModel = new ProdutoListViewModel
            {
                Produto = produto,
                OpcoesExtra = listaOpcoesExtra,
                Categorias = listaCategorias,


            };
            return View(produtosListViewModel);
                }
        public ViewResult Pesquisa(string buscarPor)
        {
            IEnumerable<Produto> produtos;
            string categoriaAtual = string.Empty;

            ViewBag.ProdutosCadastrados = _produtoRepository.Produtos;
            ViewBag.UrlCanonica = true;
            ViewBag.IndexarPagina = true;


            if (string.IsNullOrEmpty(buscarPor))
            {
                produtos = _produtoRepository.Produtos.OrderBy(p => p.ProdutoId).Where(p => !p.NaoVenderIndividualmente);
                categoriaAtual = "Todos os Produtos";
            }
            else
            {
                produtos = _produtoRepository.Produtos.Where(p => p.TagsSearch.ToLower().Contains(buscarPor.ToLower()) && !p.Categoria.EsconderCategoria);

                if (produtos.Any()) { 
                    categoriaAtual =  buscarPor ;
                 }
                else { 
                    categoriaAtual = "Nenhum produto foi encontrado";
                }
            }

            return View("~/Views/Produto/List.cshtml", new ProdutoListViewModel
            {
                Produtos = produtos,
                CategoriaAtual = categoriaAtual
            });
        }
    }
}
