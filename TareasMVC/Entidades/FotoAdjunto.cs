using Microsoft.EntityFrameworkCore;

namespace TareasMVC.Entidades
{
    public class FotoAdjunto
    {
        public Guid Id { get; set; }
        public int EvaluacionId { get; set; }
        public Evaluacion Evaluacion { get; set; }
        [Unicode(false)]
        public string Url { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
