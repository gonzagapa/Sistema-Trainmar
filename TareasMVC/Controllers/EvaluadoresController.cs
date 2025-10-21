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

        public IActionResult Editar(int Id)
        {
            return View();// ACAmbio realizado
        }


        //Agegar un modal previo a eliminar un elemento
        public async Task<IActionResult> Eliminar(int Id)
        {
            var evaluador = await context.Evaluador.FirstOrDefaultAsync(x => x.Id == Id);
            if(evaluador == null)
            {
                ModelState.AddModelError(string.Empty, "Evaluador no encontrado");
                return RedirectToAction("Index", "Evaluadores");
            }

            context.Evaluador.Remove(evaluador);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Evaluadores");
        }
    }
}
