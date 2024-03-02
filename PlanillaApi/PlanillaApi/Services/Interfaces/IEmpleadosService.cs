using PlanillaApi.Core;
using PlanillaApi.Entities;

namespace PlanillaApi.Services.Interfaces
{
    public interface IEmpleadosService
    {
        Task<ContratoResult> CrearContrato(Contrato contrato);
    }
}
