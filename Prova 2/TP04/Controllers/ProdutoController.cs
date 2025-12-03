using DAL.Produtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model;
using PROVA02.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PROVA02.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IRepository<Produto> _repo;
        private readonly UserManager<Usuario> _userManager;

        public ProdutoController(IRepository<Produto> repo, UserManager<Usuario> userManager)
        {
            _repo = repo;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_repo.All.ToList());
        }

        [HttpGet]
        public IActionResult Detalhes(int id)
        {
            var produto = _repo.Find(id);
            if (produto == null) return NotFound();
            return View(produto);
        }


        [Authorize]
        [HttpGet]
        public IActionResult Novo()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Novo(ProdutoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var produto = model.ToEntity();

                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    produto.IdUsuarioCadastro = user.Id;
                    produto.IdUsuarioUpdate = user.Id;
                }

                produto.Status = true;
                _repo.Incluir(produto);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var produto = _repo.Find(id);
            if (produto == null) return NotFound();

            var model = new ProdutoViewModel
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco,
                Status = produto.Status
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(ProdutoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var produtoOriginal = _repo.Find(model.Id);
                if (produtoOriginal == null) return NotFound();

                produtoOriginal.Nome = model.Nome;
                produtoOriginal.Preco = model.Preco;
                produtoOriginal.Status = model.Status;

                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    produtoOriginal.IdUsuarioUpdate = user.Id;
                }

                _repo.Alterar(produtoOriginal);

                return RedirectToAction("Detalhes", new { id = model.Id });
            }
            return View(model);
        }

        [Authorize]
        public IActionResult Remover(int id)
        {
            var produto = _repo.Find(id);
            if (produto != null) _repo.Excluir(produto);
            return RedirectToAction("Index");
        }
    }
}