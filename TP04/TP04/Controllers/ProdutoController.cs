using DAL.Produtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace TP04.Controllers
{

    public class ProdutoController : Controller
    {
        private readonly IRepository<Produto> _repo;

        public ProdutoController(IRepository<Produto> repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var produtos = _repo.All.ToList();
            return View(produtos);
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Novo(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _repo.Incluir(produto);
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var produto = _repo.Find(id);
            if (produto == null) return NotFound();

            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _repo.Alterar(produto);
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        public IActionResult Remover(int id)
        {
            var produto = _repo.Find(id);
            if (produto != null)
            {
                _repo.Excluir(produto);
            }
            return RedirectToAction("Index");
        }
    }
}
