using Microsoft.EntityFrameworkCore;
using PlanillaApi.Data;
using PlanillaApi.Entities;
using PlanillaApi.Repositories.Interfaces;
using System.Collections.Generic;

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
                .Include(p => p.Puestos.Where(p => p.Habilitado && p.PlazasHabilitadas > 0 && p.PlazasHabilitadas > p.Contratos.Count(c => !c.FechaFinalizacion.HasValue)))
                .AsNoTracking()
                .ToListAsync();

            return query.Where(a => a.Puestos.Any()).ToList();
        }

        
    }
}
