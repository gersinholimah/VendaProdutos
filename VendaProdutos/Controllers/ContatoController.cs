using Microsoft.AspNetCore.Mvc;
using VendaProdutos.Context;
using VendaProdutos.Repositories.Interfaces;

namespace VendaProdutos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly AppDbContext _context;

        public ContatoController(AppDbContext context)
        {
             _context = context;

        }
        public IActionResult Index()
        {
            ViewBag.idDaCategoriaAtual = 2;
            ViewBag.ProdutosCadastrados = _context.Produtos; ;
            //if (User.Identity.IsAuthenticated)
            //{
                return View();
            //}
            //return RedirectToAction("Login", "Account");
        }
    }
}
