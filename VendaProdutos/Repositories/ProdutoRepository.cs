using Microsoft.EntityFrameworkCore;
using VendaProdutos.Context;
using VendaProdutos.Models;
using VendaProdutos.Repositories.Interfaces;

namespace VendaProdutos.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;
        public ProdutoRepository(AppDbContext contexto)
        {
            _context = contexto;
        }
        public IEnumerable<Produto> Produtos => _context.Produtos.Include(c=> c.Categoria);

        public IEnumerable<Produto> ProdutosEmAlta => _context.Produtos.
            Where(p => p.IsProdutoEmAlta)
            .Include(c => c.Categoria);

        public Produto GetProdutoById(int produtoId)
        {
            return _context.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);
        }
    }
}
