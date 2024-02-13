//using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using VendaProdutos.Repositories;
using VendaProdutos.Repositories.Interfaces;
using VendaProdutos.ViewModel;

namespace VendaProdutos.Controllers
{
     
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IProdutoRepository _produtoRepository;
        //private readonly ICaptchaValidator _captchaValidator;


        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, IProdutoRepository produtoRepository
            //,ICaptchaValidator captchaValidator
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _produtoRepository = produtoRepository;
            //_captchaValidator = captchaValidator;

        }

        public IActionResult Login(string returnUrl = null)
        {
            ViewBag.ProdutosCadastrados = _produtoRepository.Produtos;
            
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)/*, string captcha*/
        {
   

            ViewBag.ProdutosCadastrados = _produtoRepository.Produtos;

            if (!ModelState.IsValid)
                return View(loginVM);

            var user = await _userManager.FindByNameAsync(loginVM.UserName);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
       //verifica se o logim ta certo e verifica se o captcha aprovou
                if (result.Succeeded)/*&& await _captchaValidator.IsCaptchaPassedAsync(captcha)*/
                {
                    if (string.IsNullOrEmpty(loginVM.ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return Redirect(loginVM.ReturnUrl);
                }
            }
            ModelState.AddModelError("", "Falha ao realizar o login!!");
            return View(loginVM);
        }

        public IActionResult Register()
        {
            ViewBag.ProdutosCadastrados = _produtoRepository.Produtos;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Register(LoginViewModel registroVM)/*, string captcha*/
        {
            ViewBag.ProdutosCadastrados = _produtoRepository.Produtos;

           

            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = registroVM.UserName, };
                var result = await _userManager.CreateAsync(user, registroVM.Password);
        //verifica se o cadastro ta certo e verifica se o captcha aprovou

                if (result.Succeeded )/*&& await _captchaValidator.IsCaptchaPassedAsync(captcha)*/
                {
                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    await _userManager.AddToRoleAsync(user, "Member");
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    this.ModelState.AddModelError("Registro", "Falha ao registrar o usuário");
                }
            }
           
                return View(registroVM);
 
        }
        [HttpPost]
      public async Task<IActionResult> Logout()
        {
            ViewBag.ProdutosCadastrados = _produtoRepository.Produtos;

            HttpContext.Session.Clear();
            HttpContext.User = null;
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            ViewBag.ProdutosCadastrados = _produtoRepository.Produtos;

            return View();
        }

    }
}
















