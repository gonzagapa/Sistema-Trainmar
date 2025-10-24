using Microsoft.AspNetCore.Mvc;
using TareasMVC.Models;

namespace TareasMVC.Controllers
{
    public class EvaluacionesController : Controller
    {
        public IActionResult Index()
        {
            var model = new EvaluacionesViewModel();
            return View(model);
        }

        public IActionResult Add() {
            return View();
        }


    }
}
