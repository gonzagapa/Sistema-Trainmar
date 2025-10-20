using Microsoft.AspNetCore.Mvc;

namespace TareasMVC.Controllers
{
    public class EvaluacionesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add() {
            return View();
        }
    }
}
