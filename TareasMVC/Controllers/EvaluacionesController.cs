using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareasMVC.Models;

namespace TareasMVC.Controllers
{
    public class EvaluacionesController : Controller
    {
        private readonly ApplicationDbContext contexto;

        public EvaluacionesController(ApplicationDbContext _context)
        {
            contexto = _context;

        }
        public async Task<IActionResult> Index()
        {
            var evaluadores = await contexto.Evaluaciones
                .Include(e => e.Evaluador)
                .Include(e => e.Terminal)
                .ToListAsync();

            var model = new EvaluacionesViewModel();
            model.Evaluaciones = evaluadores;
            return View(model);
        }

        public IActionResult Agregar() {
            return View();
        }


    }
}
