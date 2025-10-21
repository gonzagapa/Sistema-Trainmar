using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TareasMVC.Entidades;

namespace TareasMVC.Models
{
    public class TerminalViewModel
    {
        [Required]
        [StringLength(10, ErrorMessage = "La {0} no debe ser mayor a {1} caracteres.")]
        [DisplayName("Abreviatura")]
        public string AbreviaturaTerminal { get; set; }

        [DisplayName("Nombre completo terminal")]

        public string NombreTerminal { get; set; }

        public List<Evaluacion> Evaluaciones { get; set; }
    }
}
