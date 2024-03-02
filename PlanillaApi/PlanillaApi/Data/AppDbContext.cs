using Microsoft.EntityFrameworkCore;
using PlanillaApi.Entities;

namespace PlanillaApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Area> Areas { get; set; }
        public DbSet<Puesto> Puestos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(builder =>
            {
                builder.ToTable("Areas");
                builder.HasKey(area => area.Id);
                builder.Property(area => area.Id).IsRequired().UseIdentityColumn(1, 1);
                builder.Property(area => area.Descripcion).IsRequired().HasMaxLength(64);
                builder.HasOne(area => area.ReportaA).WithMany(area => area.AreasSubordinadas).HasForeignKey(area => area.ReportaAId);
            });

            modelBuilder.Entity<Puesto>(builder =>
            {
                builder.ToTable("Puestos");
                builder.HasKey(puesto => puesto.Id);
                builder.Property(puesto => puesto.Id).IsRequired().UseIdentityColumn(1, 1);
                builder.Property(puesto => puesto.Descripcion).IsRequired().HasMaxLength(64);
                builder.Property(puesto => puesto.Habilitado).HasDefaultValue(true).IsRequired();
                builder.Property(puesto => puesto.TechoSalarial).IsRequired().HasColumnType("MONEY");
                builder.Property(puesto => puesto.PlazasHabilitadas).IsRequired();
                builder.HasOne(puesto => puesto.Area).WithMany(area => area.Puestos).HasForeignKey(puesto => puesto.AreaId).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
