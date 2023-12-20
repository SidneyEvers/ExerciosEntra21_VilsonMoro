using EntityProjectNew.Data;
using EntityProjectNew.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityProjectNew.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;
        private readonly AuthDbContext _authDbContext;
        public AccountController(SignInManager<IdentityUser> signInManager, AuthDbContext authDbContext, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authDbContext = authDbContext;
        }
        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(CriarUserViewModel criarUserViewModel)
        {
            var user = new IdentityUser
            {
                UserName = criarUserViewModel.Nome,
                Email = criarUserViewModel.Email,
            };
                
            var novoUsuario = await _userManager.CreateAsync(user, criarUserViewModel.Senha);

            if (novoUsuario.Succeeded)
            {
                var role = await _userManager.AddToRoleAsync(user, "usuario");

                if (role.Succeeded)
                {
                    return RedirectToAction("Login");
                }
            }

            return View(null);
        }


        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var usuarioEncontrar = await _authDbContext.Users.FirstOrDefaultAsync(x => x.Email == loginViewModel.Email);

            var usuarioTentandoLogar = await _signInManager.PasswordSignInAsync
                (
                    usuarioEncontrar.UserName,
                    loginViewModel.Senha,
                    false,
                    false
                );
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
