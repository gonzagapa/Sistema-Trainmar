namespace TareasMVC.Models
{
    public class PaginacionViewModel
    {
        public int pagina { get; set; } = 1;
        private int registrosPorPagina = 50;
        private readonly int cantidadMaximaRegistrosPorPagina = 100;

        public int RegistrosPorPagina
        {
            get
            {
                return registrosPorPagina;
            }
            set
            {
                registrosPorPagina = (value > cantidadMaximaRegistrosPorPagina) ? cantidadMaximaRegistrosPorPagina : value;
            }
        }

        public int RegistrosASaltar => (pagina - 1) * RegistrosPorPagina;
    }
}
