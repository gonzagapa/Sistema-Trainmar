using System.ComponentModel.DataAnnotations;
using TareasMVC.Entidades;

namespace TareasMVC.Models
{
    public class EvaluacionViewModel
    {

        [Required]
        public int IdEvaluador { get; set; }

        public Evaluador Evaluador { get; set; }

        [Required]

        public int IdTerminal { get; set; }
        public Terminal Terminal { get; set; }


        [Required]
        public DateTime FechaEvaluacion { get; set; }


        [StringLength(500, ErrorMessage = "Las {0} no deben ser mayor a {1} caracteres.")]
        public string Observaciones { get; set; }

        public List<FotoAdjunto> FotosAdjuntas { get; set; }
    }
}
