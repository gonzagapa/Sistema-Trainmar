using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TareasMVC.Models.Renec
{
    public class RENECViewModel
    {
        [Required(ErrorMessage = "El codigo es obligatorio")]
        //[RegularExpression(@"^EC\\d{3,4}(\\.\\d{2})?$", ErrorMessage = "El código EC debe tener el formato 'EC' seguido de 4 dígitos, con un sufijo decimal opcional (ej. EC0008 o EC1089.01).")]
        [StringLength(10,ErrorMessage="El {0} no debe ser mayor a {1}")]
        //Agregar validacion personalizada para que el codigo tenga un formato especifico
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El {0} es un campo requerido")]

        public byte Nivel { get; set; }

        [Required(ErrorMessage = "El {0} es un campo requerido")]
        [StringLength(400, ErrorMessage = "El {0} no debe ser mayor a {1}")]

        public string Titulo { get; set; }

        [Required(ErrorMessage = "El {0} es un campo requerido")]
        [StringLength(200, ErrorMessage = "El {0} no debe ser mayor a {1}")]

        public string Comite { get; set; }

        [Required(ErrorMessage = "El {0} es un campo requerido")]
        [StringLength(300, ErrorMessage = "El {0} no debe ser mayor a {1}")]
        [DisplayName("Sector Productivo")]

        public string Sector_Productivo { get; set; }


        public string sector { get; set; }

        [Required(ErrorMessage = "El {0} es un campo requerido")]
        public string acceso { get; set; }
    }
}
