using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TareasMVC.Entidades
{
    public class Evaluador
    {
        public int Id { get; set; }

        [Required]
        [StringLength(120,ErrorMessage = "{0} no debe ser mayor a {1}")]

        public string NombreEvaluador { get; set; }

        [Required]
        [StringLength(120, ErrorMessage = "{0} no debe ser mayor a {1}")]

        public string ApellidosEvaluador { get; set; }

        public List<Evaluacion> Evaluaciones { get; set; }
    }
}
