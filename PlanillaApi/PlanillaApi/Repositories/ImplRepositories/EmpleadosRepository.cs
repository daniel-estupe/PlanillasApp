using Microsoft.EntityFrameworkCore;
using PlanillaApi.Data;
using PlanillaApi.Entities;
using PlanillaApi.Repositories.Interfaces;

namespace PlanillaApi.Repositories.ImplRepositories
{
    public class EmpleadosRepository : IEmpleadosRepository
    {
        private readonly AppDbContext _context;

        public EmpleadosRepository(AppDbContext context)
        {
            this._context = context;
        }

        public void AgregarContrato(Contrato contrato)
        {
            _context.Contratos.Add(contrato);
        }

        public async Task<bool> ExistePlazaDisponible(int puestoId)
        {
            return await _context.Puestos.Where(p => p.PlazasHabilitadas > 0 && p.PlazasHabilitadas > p.Contratos.Count(c => !c.FechaFinalizacion.HasValue)).AnyAsync();
        }

        public async Task<IEnumerable<Empleado>> ObtenerEmpleados()
        {
            var respuesta = await _context.Empleados
                .Include(e => e.Contratos.OrderBy(c => c.Id))
                .ThenInclude(c => c.Puesto)
                .ThenInclude(p => p.Area)
                .ToListAsync();
            return respuesta; 
        }

        public async Task<Empleado> ObtenerEmpleado(int id)
        {
            var resultado = await _context.Empleados
                .Include(e => e.Contratos.OrderBy(c => c.Id))
                .ThenInclude(c => c.Puesto)
                .ThenInclude(p => p.Area)
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
            return resultado!;
        }

        public async Task<Puesto> ObtenerPuestoPorId(int puestoId)
        {
            var puesto = await _context.Puestos.FindAsync(puestoId);
            return puesto!;
        }
    }
}
