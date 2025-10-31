using System.ComponentModel.DataAnnotations;

namespace TareasMVC.Entidades
{
    public class Evaluacion
    {
        [Key]
        public int Id{ get; set; }

        [Required]
        public int EvaluadorId { get; set; }

        public Evaluador Evaluador { get; set; }

        [Required]

        public int TerminalId { get; set; }
        public Terminal Terminal { get; set; }


        [Required]
        public DateTime FechaEvaluacion { get; set; }


        [Required]
        [StringLength(120, ErrorMessage = "El {0} no debe ser mayor a {1} caracteres.")]
        public string NombreEvaluado { get; set; }

        [Required]
        [StringLength(120, ErrorMessage = "Los {0} no deben ser mayor a {1} caracteres.")]
        public string ApellidoEvaluado { get; set; }


        [StringLength(500, ErrorMessage = "Las {0} no deben ser mayor a {1} caracteres.")]
        public string Observaciones { get; set; }

        public List<FotoAdjunto> FotosAdjuntas { get; set; }

        public List<Respuesta> Respuestas { get; set; }


        [Required]

        public int ExperienciaoNumeroEquipo { get; set; }


    }
}
