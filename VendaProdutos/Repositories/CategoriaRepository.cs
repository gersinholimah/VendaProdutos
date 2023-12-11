using VendaProdutos.Context;
using VendaProdutos.Models;
using VendaProdutos.Repositories.Interfaces;

namespace VendaProdutos.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
