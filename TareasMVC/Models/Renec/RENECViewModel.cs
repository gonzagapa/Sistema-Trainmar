using System.ComponentModel.DataAnnotations;

namespace TareasMVC.Models.Renec
{
    public class RENECViewModel
    {
        [Key]
        [StringLength(10,ErrorMessage="El {0} no debe ser mayor a {1}")]
        //Agregar validacion personalizada para que el codigo tenga un formato especifico
        public string Codigo { get; set; }

        [Required]

        public byte Nivel { get; set; }

        [Required]
        [StringLength(400, ErrorMessage = "El {0} no debe ser mayor a {1}")]

        public string Titulo { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "El {0} no debe ser mayor a {1}")]

        public string Comite { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "El {0} no debe ser mayor a {1}")]

        public string SectorProductivo { get; set; }


        public string sector { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "El {0} no debe ser mayor a {1}")]
        public string acceso { get; set; }
    }
}
