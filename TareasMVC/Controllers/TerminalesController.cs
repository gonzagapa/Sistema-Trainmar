using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareasMVC.Entidades;
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

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(TerminalViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var terminal = new Terminal();

            //TODO: generar un mapeo con AutoMapper
            terminal.AbreviaturaTerminal = model.AbreviaturaTerminal;
            terminal.NombreTerminal = model.NombreTerminal;

            await _context.Terminal.AddAsync(terminal);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Terminales");
        }

        [HttpGet]
        public IActionResult Editar(int Id)
        {
            var terminal = _context.Terminal.FirstOrDefault(x => x.Id == Id);
            if (terminal == null)
            {
                return NotFound();
            }
            var modelo = new TerminalViewModel();
            modelo.AbreviaturaTerminal = terminal.AbreviaturaTerminal;
            modelo.NombreTerminal = terminal.NombreTerminal;
            return View(modelo);

        }

        [HttpPost]
        public async Task<IActionResult> Editar(int Id, TerminalViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var terminal = await _context.Terminal.FirstOrDefaultAsync(x => x.Id == Id);
            if (terminal == null)
            {
                return NotFound();
            }
            terminal.AbreviaturaTerminal = model.AbreviaturaTerminal;
            terminal.NombreTerminal = model.NombreTerminal;
            _context.Terminal.Update(terminal);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "terminales");
        }


        //Agegar un modal previo a eliminar un elemento
        //public async Task<IActionResult> Eliminar(int Id)
        //{
        //    var terminal = await _context.Terminal.FirstOrDefaultAsync(x => x.Id == Id);
        //    if (terminal == null)
        //    {
        //        // Devuelve JSON con el estado de la respuesta
        //        return Json(new { success = false, message = "Terminal no encontrada." });
        //    }

        //    _context.Terminal.Remove(terminal);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index", "Terminales");
        //}

        [HttpPost]
        public async Task<IActionResult> Eliminar(int Id)
        {
            var terminal = await _context.Terminal.FirstOrDefaultAsync(x => x.Id == Id);
            if (terminal == null)
            {
                return Json(new { success = false, message = "Terminal no encontrada." });
            }

            _context.Terminal.Remove(terminal);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = $"La terminal '{terminal.NombreTerminal}' ha sido eliminada correctamente." });
        }
    }
}
