using Microsoft.AspNetCore.Authorization; // <--- NÃO ESQUEÇA DE ADICIONAR ISSO
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model;
using PROVA02.Models;
using System.Threading.Tasks;

namespace PROVA02.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public UsuarioController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

       
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            await _signInManager.SignOutAsync();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Login, model.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Produto");
                }

                ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos.");
            }
            return View(model);
        }


        //[Authorize]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"TENTATIVA DE CADASTRO: {model.Login}");

            if (ModelState.IsValid)
            {
                try
                {
                    var user = new Usuario
                    {
                        UserName = model.Login,
                        Nome = model.Nome,
                        Status = true,
                        Email = "fake_" + model.Login + "@email.com" // Garante email preenchido
                    };

                    // AQUI É ONDE O ERRO PODE ACONTECER
                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        Console.WriteLine(">>> SUCESSO! USUÁRIO CRIADO NO BANCO <<<");
                        TempData["Sucesso"] = "Usuário criado! Tente logar.";
                        return RedirectToAction("Index", "Produto");
                    }

                    // SE FALHOU NO IDENTITY:
                    Console.WriteLine(">>> FALHA NO IDENTITY <<<");
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"ERRO: {error.Code} - {error.Description}");
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                catch (Exception ex)
                {
                    // SE O BANCO DE DADOS EXPLODIU:
                    Console.WriteLine(">>> EXCEÇÃO CRÍTICA (CRASH) <<<");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.InnerException?.Message);
                    ModelState.AddModelError(string.Empty, "Erro interno no servidor: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine(">>> MODELSTATE INVÁLIDO (Formulário com erro) <<<");
                foreach (var erro in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Erro de Validação: {erro.ErrorMessage}");
                }
            }

            return View(model);
        }

        // --- LOGOUT ---
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}