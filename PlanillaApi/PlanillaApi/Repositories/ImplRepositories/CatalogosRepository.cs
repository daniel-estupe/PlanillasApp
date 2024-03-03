using Microsoft.EntityFrameworkCore;
using PlanillaApi.Data;
using PlanillaApi.Entities;
using PlanillaApi.Repositories.Interfaces;

namespace PlanillaApi.Repositories.ImplRepositories
{
    public class CatalogosRepository : ICatalogosRepository
    {
        private readonly AppDbContext context;

        public CatalogosRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Area>> ObtenerAreasConPuestosDisponibles()
        {
            var query = await context.Areas
                .Include(p => p.Puestos.Where(p => p.Habilitado && p.PlazasHabilitadas > p.Contratos.Count(c => !c.FechaFinalizacion.HasValue)))
                .ThenInclude(p => p.Contratos)
                .Where(a => a.Puestos.Count > 0)
                .AsNoTracking()
                .ToListAsync();
            return query;
        }

        
    }
}
