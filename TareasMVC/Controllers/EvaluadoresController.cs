using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareasMVC.Entidades;
using TareasMVC.Models;

namespace TareasMVC.Controllers
{
    public class EvaluadoresController : Controller
    {
        private readonly ApplicationDbContext context;

        public EvaluadoresController(ApplicationDbContext conte)
        {
            context = conte;
        }
        public async Task<IActionResult> Index()
        {
            var evaluadores = await context.Evaluador.ToListAsync();
            var modelos = new EvaluadoresViewModel();
            modelos.Evaluadores = evaluadores;
            return View(modelos);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(EvaluadorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var evaluador = new Evaluador();

            //TODO: generar un mapeo con AutoMapper
            evaluador.NombreEvaluador = model.NombreEvaluador;
            evaluador.ApellidosEvaluador = model.ApellidosEvaluador;
           
            await context.Evaluador.AddAsync(evaluador);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Evaluadores");
        }

        [HttpGet]
        public IActionResult Editar(int Id)
        {
            var evaluador = context.Evaluador.FirstOrDefault(x => x.Id == Id);
            if(evaluador == null)
            {
                return NotFound();
            }
            var modelo = new EvaluadorViewModel();
            modelo.NombreEvaluador = evaluador.NombreEvaluador;
            modelo.ApellidosEvaluador = evaluador.ApellidosEvaluador;
            return View(modelo);

        }

        [HttpPost]
        public async Task<IActionResult> Editar(int Id, EvaluadorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var evaluador = await context.Evaluador.FirstOrDefaultAsync(x => x.Id == Id);
            if(evaluador == null)
            {
                return NotFound();
            }
            evaluador.NombreEvaluador = model.NombreEvaluador;
            evaluador.ApellidosEvaluador = model.ApellidosEvaluador;
            context.Evaluador.Update(evaluador);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Evaluadores");
        }


        //Agegar un modal previo a eliminar un elemento
        public async Task<IActionResult> Eliminar(int Id)
        {
            var evaluador = await context.Evaluador.FirstOrDefaultAsync(x => x.Id == Id);
            if(evaluador == null)
            {
                return NotFound();
            }

            context.Evaluador.Remove(evaluador);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Evaluadores");
        }
    }
}
