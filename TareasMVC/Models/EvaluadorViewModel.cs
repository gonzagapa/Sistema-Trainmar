using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TareasMVC.Models
{
    public class EvaluadorViewModel
    {
        [Required]
        [StringLength(120, ErrorMessage = "{0} no debe ser mayor a {1}")]
        [DisplayName("Nombre del evaluador")]
        public string NombreEvaluador { get; set; }

        [Required]
        [StringLength(120, ErrorMessage = "{0} no debe ser mayor a {1}")]
        [DisplayName("Apellidos del evaluador")]

        public string ApellidosEvaluador { get; set; }
    }
}
