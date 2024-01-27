using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using VendaProdutos.Context;
using VendaProdutos.Models;

namespace VendaProdutos.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminProdutosController : Controller
    {
        private readonly AppDbContext _context;

        public AdminProdutosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminProdutos
        //public async Task<IActionResult> Index()
        //{
        //    var appDbContext = _context.Produtos.Include(p => p.Categoria);
        //    return View(await appDbContext.ToListAsync());
        //}

        public async Task<IActionResult> Index(string nomeFilter, string categoriaFilter, int pageindex = 1, string sort = "Nome")
        {
            var resultado = _context.Produtos.Include(l => l.Categoria).AsQueryable();

            if (!string.IsNullOrWhiteSpace(nomeFilter))
            {
                resultado = resultado.Where(p => p.Nome.Contains(nomeFilter));
            }
            if (!string.IsNullOrWhiteSpace(categoriaFilter))
            {
                resultado = resultado.Where(p => p.Categoria.CategoriaNome.Contains(categoriaFilter));
            }
           

            var model = await PagingList.CreateAsync(resultado, 10, pageindex, sort, "Nome");
            model.RouteValue = new RouteValueDictionary {
                { "nomeFilter", nomeFilter },
                { "categoriaFilter", categoriaFilter }
            };
            return View(model);
        }

        // GET: Admin/AdminProdutos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Admin/AdminProdutos/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome");
            return View();
        }

        // POST: Admin/AdminProdutos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoId,Sku,Altura,Largura,Profundidade,Comprimento,Peso,GaleriaImagemURL,Imagem2CarolselURL,Imagem3CarolselURL,Imagem4CarolselURL,DescricaoImgTagAlt,Nome,DescricaoCurta,DescricaoDetalhada,PostInferior,PrecoPromocional,Preco,Parcela,MetaDescricao,MetaImage,MetaTitle,UrlAmigavel,ImagemUrl,ImagemThumbnailUrl,IsProdutoEmAlta,Esgotado,TaxaDeEntrega,SobEncomenda,QuantidadeDeItem,CategoriaId,OpcaoExtra,NaoVenderIndividualmente,TagsSearch")] Produto produto)

        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", produto.CategoriaId);
            return View(produto);
        }

        // GET: Admin/AdminProdutos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", produto.CategoriaId);
            return View(produto);
        }

        // POST: Admin/AdminProdutos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdutoId,Sku,Altura,Largura,Profundidade,Comprimento,Peso,GaleriaImagemURL,Imagem2CarolselURL,Imagem3CarolselURL,Imagem4CarolselURL,DescricaoImgTagAlt,Nome,DescricaoCurta,DescricaoDetalhada,PostInferior,PrecoPromocional,Preco,Parcela,MetaDescricao,MetaImage,MetaTitle,UrlAmigavel,ImagemUrl,ImagemThumbnailUrl,IsProdutoEmAlta,Esgotado,TaxaDeEntrega,SobEncomenda,QuantidadeDeItem,CategoriaId,OpcaoExtra,NaoVenderIndividualmente,TagsSearch")] Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.ProdutoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", produto.CategoriaId);
            return View(produto);
        }

        // GET: Admin/AdminProdutos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Admin/AdminProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.ProdutoId == id);
        }
    }
}
