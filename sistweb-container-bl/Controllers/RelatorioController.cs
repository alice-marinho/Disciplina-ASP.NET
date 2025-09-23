using Microsoft.AspNetCore.Mvc;
using sistweb_container_bl.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace sistweb_container_bl.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly AppDbContext _context;

        public RelatorioController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Busca todos os BLs e inclui os containers de cada um
            var blsComContainers = await _context.BL
                .Include(b => b.Containers)
                .ToListAsync();

            return View(blsComContainers);
        }
    }
}
