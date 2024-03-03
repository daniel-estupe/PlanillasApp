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

        public Task<Contrato> AgregarContrato(Contrato contrato)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistePlazaDisponible(int puestoId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Empleado>> ObtenerEmpleados()
        {
            return await _context.Empleados
                .Include(e => e.Contratos.Where(c => !c.FechaFinalizacion.HasValue))
                .ThenInclude(c => c.Puesto)
                .ThenInclude(p => p.Area)
                .ToListAsync();
        }

        public Task<Puesto> ObtenerPuestoPorId(int puestoId)
        {
            throw new NotImplementedException();
        }
    }
}
