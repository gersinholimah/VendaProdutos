using Microsoft.AspNetCore.Mvc;
using VendaProdutos.Areas.Admin.Servicos;
 
namespace VendaProdutos.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminGraficoController : Controller
    {
        private readonly GraficoVendasService _graficoVendas;

        public AdminGraficoController(GraficoVendasService graficoVendas)
        {
            _graficoVendas = graficoVendas ?? throw
                new ArgumentNullException(nameof(graficoVendas));
        }

        public JsonResult VendasProdutos(int dias, bool incluirPagamento) {
            var produtosVendasTotais = _graficoVendas.GetVendasProdutos(dias, incluirPagamento);
            return Json(produtosVendasTotais);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult VendasMensal()
        {
            return View();
        }

        [HttpGet]
        public IActionResult VendasSemanal()
        {
            return View();
        }


    }
}
