using System.ComponentModel.DataAnnotations;

namespace TareasMVC.Entidades
{

    public enum EstadoRespuesta
    {
        Si,
        No,
        Otro
    }
    public class EvaluacionFijo3: Evaluacion
    {
        [Required]
        public EstadoRespuesta D1  { get; set; }

        [MaxLength(500)]
        public string TextoOtro1 { get; set; }

        [Required]


        public EstadoRespuesta D2 { get; set; }
        [MaxLength(500)]
        public string TextoOtro2 { get; set; }

        [Required]

        public EstadoRespuesta D3 { get; set; }
        [MaxLength(500)]
        public string TextoOtro3 { get; set; }
    }
}
