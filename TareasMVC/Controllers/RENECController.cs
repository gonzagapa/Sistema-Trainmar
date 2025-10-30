using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TareasMVC.Entidades;
using TareasMVC.Models;
using TareasMVC.Models.Renec;
using TareasMVC.Servicios;

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
        public async Task<IActionResult> Index(PaginacionViewModel paginacion)
        {
            var renec = await context.RENEC
                .OrderBy(r => r.Codigo)
                .Skip(paginacion.RegistrosASaltar)
                .Take(paginacion.RegistrosPorPagina)
                .ToListAsync();

            var totalRegistros = await this.Contar();
            var respuestaPaginacion = new PaginacionRespuestaModel<RENEC>
            {
                CantidadTotalRegistros = totalRegistros,
                pagina = paginacion.pagina,
                BaseURL = "/renec",
                Registros = renec
            };
            return View(respuestaPaginacion);
        }

        public async Task<int> Contar()
        {
          return await context.RENEC.CountAsync();
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

        [Authorize(Roles =Constantes.RolAdmin)]
        [HttpGet]
        public async Task<IActionResult> Editar(string codigo)
        {
            var renec = await context.RENEC.FirstOrDefaultAsync( r => r.Codigo == codigo);
            var model = mapper.Map<RENECViewModel>(renec);
            ViewBag.AccesoSelectList = new SelectList(Constantes.listaAcceso, "Nombre", "Nombre");
            return View(model);
        }


        [Authorize(Roles = Constantes.RolAdmin)]
        [HttpPost]
        public async Task<IActionResult> Editar(RENECViewModel model)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.AccesoSelectList = new SelectList(Constantes.listaAcceso, "Nombre", "Nombre");
                return View("Editar", model);
            }
            var renec = await context.RENEC.FirstOrDefaultAsync(r => r.Codigo == model.Codigo);
            if(renec == null)
            {
                return NotFound();
            }

            mapper.Map(model,renec);
            context.RENEC.Update(renec);
            await context.SaveChangesAsync();
            return RedirectToAction("Index",
               routeValues: new { mensaje = "modificancion realizada a " + model.Codigo });
        }


        [Authorize(Roles = Constantes.RolAdmin)]
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

        [Authorize(Roles = Constantes.RolAdmin)]
        public IActionResult Agregar()
        {

            ViewBag.AccesoSelectList = new SelectList(Constantes.listaAcceso, "Nombre", "Nombre");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(RENECViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.AccesoSelectList = new SelectList(Constantes.listaAcceso, "Nombre", "Nombre");
                return View(model);
            }

            //Validar que no exista un codigo igual
            bool existeCodigo = await context.RENEC.AnyAsync(r => r.Codigo == model.Codigo);
            if (existeCodigo)
            {

                ViewBag.AccesoSelectList = new SelectList(Constantes.listaAcceso, "Nombre", "Nombre");
                ModelState.AddModelError(nameof(model.Codigo), $"El código {model.Codigo} ya existe en el registro ");
                return View(model);
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
