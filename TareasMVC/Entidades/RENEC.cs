using System.ComponentModel.DataAnnotations;

namespace TareasMVC.Entidades
{
    public class RENEC
    {
        [Key]
        public string Codigo { get; set; }

        public byte Nivel { get; set;  }


        public string Titulo { get; set;  }

        public string Comite { get; set; }

        public string Sector_Productivo { get; set; }

        public string sector { get; set; }

        public string acceso { get; set; }

    }
}
