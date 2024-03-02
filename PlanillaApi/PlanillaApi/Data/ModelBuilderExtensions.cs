using Microsoft.EntityFrameworkCore;
using PlanillaApi.Entities;

namespace PlanillaApi.Data
{
    public static class ModelBuilderExtensions
    {
        public static void AddAreaConfig(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(builder =>
            {
                builder.ToTable("Areas");
                builder.HasKey(area => area.Id);
                builder.Property(area => area.Id).IsRequired().UseIdentityColumn(1, 1);
                builder.Property(area => area.Descripcion).IsRequired().HasMaxLength(64);
                builder.HasOne(area => area.ReportaA).WithMany(area => area.AreasSubordinadas).HasForeignKey(area => area.ReportaAId);
            });
        }

        public static void AddPuestoConfig(this ModelBuilder modelBuilder)
        {
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
        }

        public static void AddEmpleadoConfig(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>(builder =>
            {
                builder.ToTable("Empleados");
                builder.HasKey(empleado => empleado.Id);
                builder.Property(empleado => empleado.Id).IsRequired().UseIdentityColumn(1, 1);
                builder.Property(empleado => empleado.Nombres).IsRequired().HasMaxLength(256);
                builder.Property(empleado => empleado.Apellidos).IsRequired().HasMaxLength(256);
                builder.Property(empleado => empleado.Genero).IsRequired().HasMaxLength(256);
                builder.Property(empleado => empleado.EstadoCivil).IsRequired().HasMaxLength(256);
                builder.Property(empleado => empleado.FechaNacimiento).IsRequired();
                builder.Property(empleado => empleado.CUI).IsRequired().HasMaxLength(13).IsFixedLength();
                builder.Property(empleado => empleado.NIT).IsRequired().HasMaxLength(13).IsFixedLength();
                builder.Property(empleado => empleado.Pasaporte).HasMaxLength(20).IsFixedLength();
                builder.Property(empleado => empleado.AfiliacionIGSS).HasMaxLength(20).IsFixedLength();
                builder.Property(empleado => empleado.AfiliacionIRTRA).HasMaxLength(20).IsFixedLength();
            });
        }

        public static void AddContratoConfig(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contrato>(builder =>
            {
                builder.ToTable("Contratos");
                builder.HasKey(contrato => contrato.Id);
                builder.Property(contrato => contrato.Id).IsRequired().UseIdentityColumn(1, 1);
                builder.HasOne(contrato => contrato.Empleado).WithMany(empleado => empleado.Contratos).HasForeignKey(contrato => contrato.EmpleadoId).IsRequired();
                builder.HasOne(contrato => contrato.Puesto).WithMany(puesto => puesto.Contratos).HasForeignKey(contrato => contrato.PuestoId).IsRequired();
                builder.Property(contrato => contrato.FechaInicio).IsRequired();
                builder.Property(contrato => contrato.SalarioBase).IsRequired().HasColumnType("MONEY");
                builder.Property(contrato => contrato.Bonificacion).IsRequired().HasColumnType("MONEY");
            });
        }
    }
}
