using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sistweb_container_bl.Models;
using System.Linq;
using System.Threading.Tasks;

/***
 * @author: Alice Marinho 
 ***/

namespace sistweb_container_bl.Controllers
{
    public class ContainersController : Controller
    {
        private readonly AppDbContext _context;

        public ContainersController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var containers = _context.Containers.Include(c => c.BL);
            return View(await containers.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var container = await _context.Containers
                .Include(c => c.BL)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (container == null) return NotFound();

            return View(container);
        }

        public IActionResult Create()
        {
            ViewData["id_bl"] = new SelectList(_context.BL, "Id", "numero");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,numero,tipo,tamanho,id_bl")] Container container)
        {
            if (ModelState.IsValid)
            {
                _context.Add(container);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_bl"] = new SelectList(_context.BL, "Id", "numero", container.id_bl);
            return View(container);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var container = await _context.Containers.FindAsync(id);
            if (container == null) return NotFound();

            ViewData["id_bl"] = new SelectList(_context.BL, "Id", "numero", container.id_bl);
            return View(container);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,numero,tipo,tamanho,id_bl")] Container container)
        {
            if (id != container.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(container);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw; 
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_bl"] = new SelectList(_context.BL, "Id", "numero", container.id_bl);
            return View(container);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var container = await _context.Containers
                .Include(c => c.BL)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (container == null) return NotFound();

            return View(container);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var container = await _context.Containers.FindAsync(id);
            _context.Containers.Remove(container);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}