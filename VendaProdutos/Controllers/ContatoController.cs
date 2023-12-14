using Microsoft.AspNetCore.Mvc;

namespace VendaProdutos.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
