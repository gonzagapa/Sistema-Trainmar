using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    }
}
