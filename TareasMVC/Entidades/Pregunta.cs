namespace TareasMVC.Entidades
{
    public enum EstadoRespuesta
    {
        Si,
        No,
        NA
    }
    public class Pregunta
    {
        public int Id { get; set; }

        public string DescripcionPregunta { get; set; }

        public List<Respuesta> Respuestas { get; set; }

    }
}
