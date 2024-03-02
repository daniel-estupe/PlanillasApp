using Microsoft.EntityFrameworkCore;
using PlanillaApi.Entities;

namespace PlanillaApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Area> Areas { get; set; }
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

            base.OnModelCreating(modelBuilder);
        }
    }
}
