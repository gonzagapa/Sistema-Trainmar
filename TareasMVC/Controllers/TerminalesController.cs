using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareasMVC.Models;

namespace TareasMVC.Controllers
{
    public class TerminalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TerminalesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var terminales = await _context.Terminal.ToListAsync();
            var modelos = new TerminalesViewModel();
            modelos.Terminales = terminales;
            return View(modelos);
        }
    }
}
