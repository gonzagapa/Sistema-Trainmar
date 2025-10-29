using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TareasMVC.Entidades;

namespace TareasMVC
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Evaluacion> Evaluaciones { get; set; }

        public DbSet<Evaluador> Evaluador { get; set; }

        public DbSet<Terminal> Terminal { get; set; }

        public DbSet<FotoAdjunto> Fotografias { get; set; }

        public DbSet<RENEC> RENEC { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RENEC>().
                ToTable("RENEC")
                .HasKey(r => r.Codigo);

            //modelBuilder.Entity<Tarea>().Property(t => t.Titulo).HasMaxLength(250).IsRequired();

            modelBuilder.Entity<Terminal>()
                .HasData(
                    new Terminal { Id = 1, AbreviaturaTerminal = "ICAVE"},
                    new Terminal { Id = 2, AbreviaturaTerminal = "TIMSA" },
                    new Terminal { Id = 3, AbreviaturaTerminal = "TILH" },
                    new Terminal { Id = 4, AbreviaturaTerminal = "EIT" }
                );
            modelBuilder.Entity<Evaluador>()
                .HasData(
                    new Evaluador { Id = 1, NombreEvaluador = "Ruben Dario", ApellidosEvaluador = "Rodriguez Urreta" },
                    new Evaluador { Id = 2, NombreEvaluador = "Luis", ApellidosEvaluador = "Alvarez Benitez" },
                    new Evaluador { Id = 3, NombreEvaluador = "Laura", ApellidosEvaluador = "Gomez Hernandez" },
                    new Evaluador { Id = 4, NombreEvaluador = "Paola", ApellidosEvaluador = "Izquierdo Jaramillo" },
                    new Evaluador { Id = 5, NombreEvaluador = "Varick", ApellidosEvaluador = "Varas Violante"}
                );
        }
    }
}
