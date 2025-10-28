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
        public EstadoRespuesta D1  { get; set; }

        public EstadoRespuesta D2 { get; set; }

        public EstadoRespuesta D3 { get; set; }
    }
}
