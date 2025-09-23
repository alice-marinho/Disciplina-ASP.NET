using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistweb_container_bl.Models; 
using System.Threading.Tasks;

/***
 * @author: Alice Marinho 
 ***/

namespace sistweb_container_bl.Controllers
{
    public class BLController : Controller
    {
        private readonly AppDbContext _context;

        public BLController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /BL
        public async Task<IActionResult> Index()
        {
            var bl = await _context.BL.ToListAsync();
            return View(bl);
        }

        // GET: /BL/Details
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var bl = await _context.BL.FirstOrDefaultAsync(m => m.Id == Id);

            if (bl == null)
            {
                return NotFound();
            }

            return View(bl);
        }

        // GET: /BL/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /BL/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,numero,consignee,navio")] BL bl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bl); 
        }

        // GET: /BL/Edit/
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var bl = await _context.BL.FindAsync(Id);
            if (bl == null)
            {
                return NotFound();
            }
            return View(bl);
        }

        // POST: /BL/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, [Bind("Id,numero,consignee,navio")] BL bl)
        {
            if (Id != bl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bl);
        }

        // GET: /BL/Delete/
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var bl = await _context.BL.FirstOrDefaultAsync(m => m.Id == Id);
            if (bl == null)
            {
                return NotFound();
            }

            return View(bl);
        }

        // POST: /BL/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            var bl = await _context.BL.FindAsync(Id);
            if (bl != null)
            {
                _context.BL.Remove(bl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}