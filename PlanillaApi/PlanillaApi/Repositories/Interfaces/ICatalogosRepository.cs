using PlanillaApi.Entities;

namespace PlanillaApi.Repositories.Interfaces
{
    public interface ICatalogosRepository
    {
        Task<IEnumerable<Area>> ObtenerAreasConPuestosDisponibles();
    }
}
