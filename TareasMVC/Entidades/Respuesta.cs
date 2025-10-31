namespace TareasMVC.Entidades
{
    public class Respuesta
    {
        public int Id { get; set; }

        public EstadoRespuesta estado { get; set; }
        public string TextoOtro { get; set; }

        public int EvaluacionId { get; set; }
        public Evaluacion Evaluacion { get; set; }

        public int PreguntaId { get; set; }
        public Pregunta Pregunta { get; set; }
    }
}
