using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareasMVC.Entidades;
using TareasMVC.Models.Renec;

namespace TareasMVC.Controllers
{
    public class RENECController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public RENECController(ApplicationDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }
        public async Task<IActionResult> Index()
        {
            var renec = await context.RENEC.ToListAsync();
            var model = new RENECListaViewModel();
            model.ListaRenec = renec;
            return View(model);
        }

        public async  Task<IActionResult> Ver(string codigo)
        {
            if(codigo == null)
            {
                return NotFound();
            }
            var renec = await context.RENEC.FirstOrDefaultAsync(r => r.Codigo == codigo);
            var model = mapper.Map<RENECViewModel>(renec);
           
            return View(model);
        }

        [Authorize(Roles = Servicios.Constantes.RolAdmin)]
        public async Task<IActionResult> Editar()
        {
            var renec = await context.RENEC.FirstOrDefaultAsync();
            var model = mapper.Map<RENECViewModel>(renec);
            return View(model);
        }


        [Authorize(Roles = Servicios.Constantes.RolAdmin)]
        public async Task<IActionResult> EditarRegistro(RENECViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View("Editar", model);
            }
            var renec = await context.RENEC.FirstOrDefaultAsync(r => r.Codigo == model.Codigo);
            if(renec == null)
            {
                return NotFound();
            }
            renec = mapper.Map<RENECViewModel, RENEC>(model, renec);
            await context.RENEC.AddAsync(renec);
            await context.SaveChangesAsync();
            return RedirectToAction("Index",
               routeValues: new { mensaje = "modificancion realizada a " + model.Codigo });
        }


        [Authorize(Roles = Servicios.Constantes.RolAdmin)]
        public async Task<IActionResult> Eliminar(string codigo)
        {
            var renec = await context.RENEC.FirstOrDefaultAsync(r => r.Codigo == codigo);
            if(renec == null)
            {
                return NotFound();
            }
            context.RENEC.Remove(renec);
            await context.SaveChangesAsync();
            return RedirectToAction("Index",
               routeValues: new { mensaje = "Elemento " + codigo + " Eliminado" });
        }

        [Authorize(Roles = Servicios.Constantes.RolAdmin)]
        public IActionResult Agregar()
        {
            return View();
        }

        [Authorize(Roles = Servicios.Constantes.RolAdmin)]
        [HttpPost]
        public async Task<IActionResult> Agregar(RENECViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Agregar",model);
            }
            var renec = mapper.Map<RENECViewModel, RENEC>(model);
            await context.RENEC.AddAsync(renec);
            await context.SaveChangesAsync();
            return RedirectToAction("Index",
                "RENEC",
               routeValues: new { mensaje = "Elemento " + model.Codigo + " Agregado" });
        }
    }
}
