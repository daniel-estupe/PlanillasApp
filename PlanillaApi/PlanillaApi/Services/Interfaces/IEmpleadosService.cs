using PlanillaApi.Core;
using PlanillaApi.Entities;

namespace PlanillaApi.Services.Interfaces
{
    public interface IEmpleadosService
    {
        Task<IEnumerable<Empleado>> GetAll();
        Task<Empleado> GetById(int id);
        Task<ContratoResult> CrearContrato(Empleado empleado);
    }
}
