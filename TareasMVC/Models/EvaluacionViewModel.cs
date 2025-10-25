using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TareasMVC.Entidades;

namespace TareasMVC.Models
{
    public class EvaluacionViewModel
    {

        [Required(ErrorMessage = "El {0} es obligatorio")]
        [Display(Name = "Evaluador")]
        public int EvaluadorId { get; set; }


        public Evaluador Evaluador { get; set; }

        [Required(ErrorMessage = "La terminal es obligatoria")]
        [Display(Name = "Terminal")]

        public int TerminalId { get; set; }
        public Terminal Terminal { get; set; }


        [Required]
        [Display(Name = "Fecha de evaluacion")]
        public DateTime FechaEvaluacion { get; set; }

        [Required]
        [StringLength(120, ErrorMessage = "El {0} no debe ser mayor a {1} caracteres.")]
        [Display(Name = "Nombre(s) del evaluado")]
        public string NombreEvaluado { get; set; }

        [Required]
        [StringLength(120, ErrorMessage = "Los {0} no deben ser mayor a {1} caracteres.")]
        [Display(Name = "Apellidos del evaluado")]
        public string ApellidoEvaluado { get; set; }


        [StringLength(500, ErrorMessage = "Las {0} no deben ser mayor a {1} caracteres.")]
        public string Observaciones { get; set; }

        public List<FotoAdjunto> FotosAdjuntas { get; set; }

        [Required(ErrorMessage = "El contenido de las respuestas es obligatorio.")]
        [Display(Name = "Preguntas y Respuestas (Formato JSON)")]
        // Se recomienda almacenar un objeto JSON que contenga un array de preguntas con sus respuestas:
        // { "preguntas": [ { "id": "D3", "pregunta": "...", "respuesta": "Sí/No/NA" }, ... ] }
        public string RespuestasJson { get; set; }

        //DropDownList/Listas desplegables en la vista
        public List<SelectListItem> Terminales { get; set; }
        public List<SelectListItem> Evaluadores { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Experiencia, Años de labor o número de equipo")]

        public int ExperienciaoNumeroEquipo { get; set; }
    }
}
