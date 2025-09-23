using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistweb_container_bl.Models;
using System.Diagnostics;
using sistweb_container_bl.Models;

/***
 * @author: Alice Marinho 
 ***/

namespace sistweb_container_bl.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
         private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var blsRecentes = await _context.BL
                .OrderByDescending(b => b.Id)
                .Take(3)
                .ToListAsync();

            return View(blsRecentes);
        }

        /* public IActionResult Index()
         {
             return View();
         }*/

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
