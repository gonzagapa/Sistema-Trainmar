namespace TareasMVC.Models
{
    public class PaginacionRespuestaModel
    {
        public int pagina { get; set; } = 1;
        public int registrosPorPagina = 50;

        public int CantidadTotalRegistros { get; set; }
        public int CantidadTotalDePaginas => (int)Math.Ceiling((double)CantidadTotalRegistros / registrosPorPagina);

        public string BaseURL { get; set; } = string.Empty;

        public string Mensaje { get; set; }
    }

    public class PaginacionRespuestaModel<T>: PaginacionRespuestaModel
    {
        public List<T> Registros { get; set; }
    }
}
