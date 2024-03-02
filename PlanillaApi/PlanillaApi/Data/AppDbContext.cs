using Microsoft.EntityFrameworkCore;
using PlanillaApi.Entities;

namespace PlanillaApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Area> Areas { get; set; }
        public DbSet<Puesto> Puestos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddAreaConfig();
            modelBuilder.AddPuestoConfig();
            modelBuilder.AddEmpleadoConfig();
            modelBuilder.AddContratoConfig();

            base.OnModelCreating(modelBuilder);
        }
    }
}
