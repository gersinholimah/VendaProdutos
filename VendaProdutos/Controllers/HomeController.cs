using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VendaProdutos.Models;
using VendaProdutos.Repositories.Interfaces;
using VendaProdutos.ViewModel;

namespace VendaProdutos.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                ProdutosEmAlta = _produtoRepository.ProdutosEmAlta
            };
            ViewBag.MenuHomeAtivo = true;
            return View(homeViewModel);
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {
                RequestId = Activity.Current?.Id 
                ?? HttpContext.TraceIdentifier });
        }
    }
}
