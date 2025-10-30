using Microsoft.AspNetCore.Mvc.Rendering;

namespace TareasMVC.Servicios
{
   
    public class Constantes
    {
        public const string RolAdmin = "admin";

        public const string RolUser = "user"; 

        public static readonly SelectListItem[] CulturasUISoportadas = new SelectListItem[]
        {
            new SelectListItem{Value = "es", Text = "Español"},
            new SelectListItem{Value = "en", Text = "English"}
        };

        // 1. Datos de ejemplo
            public static List<Acceso> listaAcceso = new List<Acceso>()
        {
            new Acceso { Id = 1, Nombre = "Libre" },
            new Acceso { Id = 2, Nombre = "Opinion" },
            new Acceso { Id = 3, Nombre = "Restringido" }
        };


    }

    public class Acceso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    
}
