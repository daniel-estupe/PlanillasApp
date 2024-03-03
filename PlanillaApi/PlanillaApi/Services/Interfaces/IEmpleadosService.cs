using PlanillaApi.Core;
using PlanillaApi.Entities;

namespace PlanillaApi.Services.Interfaces
{
    public interface IEmpleadosService
    {
        Task<IEnumerable<Empleado>> GetAll();
        Task<ContratoResult> CrearContrato(Contrato contrato);
    }
}
