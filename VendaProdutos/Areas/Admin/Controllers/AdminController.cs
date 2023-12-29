using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VendaProdutos.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("Admin")]

    [Microsoft.AspNetCore.Authorization.Authorize]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
