using Microsoft.AspNetCore.Mvc;
using VendaProdutos.Repositories.Interfaces;

namespace VendaProdutos.Components
{
    public class CategoriaMenu: ViewComponent
    {
        private readonly ICategoriaRepository _CategoriaRepository;

        public CategoriaMenu(ICategoriaRepository categoriaRepository)
        {
            _CategoriaRepository = categoriaRepository;
        }
        public IViewComponentResult Invoke() {
            var categorias = _CategoriaRepository.Categorias.OrderBy(
                c => c.CategoriaNome);
            return View(categorias);
                
                }
    }
}
