using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TareasMVC.Entidades;
using TareasMVC.Models;

namespace TareasMVC.Controllers
{
    public class EvaluacionesController : Controller
    {
        private readonly ApplicationDbContext contexto;
        private readonly IMapper mapper;

        public EvaluacionesController(ApplicationDbContext _context, IMapper _mapper)
        {
            contexto = _context;
            mapper = _mapper;

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
            var _terminales = contexto.Terminal.Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.AbreviaturaTerminal }).ToList();
            var _evaluadores = contexto.Evaluador.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.NombreEvaluador + " " + e.ApellidosEvaluador }).ToList();
            var model = new EvaluacionViewModel
            {
                Terminales = _terminales,
                Evaluadores = _evaluadores
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(EvaluacionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var evaluacion = mapper.Map<Evaluacion>(model);
            await contexto.Evaluaciones.AddAsync(evaluacion);
            await contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Ver()
        {
            return View();
        }


    }
}
