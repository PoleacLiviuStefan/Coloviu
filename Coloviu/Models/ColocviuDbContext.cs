using Microsoft.EntityFrameworkCore;
using Coloviu.Models; // Asigurați-vă că adăugați direcția using pentru modelele dvs.
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Coloviu.Data
{
    public class ColocviuDbContext : DbContext
    {
        public ColocviuDbContext(DbContextOptions<ColocviuDbContext> options)
            : base(options)
        {
        }

        public DbSet<Profesor> Profesori { get; set; }
        public DbSet<Materie> Materii { get; set; }
        public DbSet<AsignareMaterie> AsignariMaterii { get; set; }

        // Aici puteți adăuga logica pentru configurarea suplimentară a modelului
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurații suplimentare (dacă este necesar)
        }
    }
}
