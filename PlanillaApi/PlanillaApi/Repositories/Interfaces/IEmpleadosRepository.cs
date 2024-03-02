using PlanillaApi.Entities;

namespace PlanillaApi.Repositories.Interfaces
{
    public interface IEmpleadosRepository
    {
        Task<bool> ExistePlazaDisponible(int puestoId);
        Task<Puesto> ObtenerPuestoPorId(int puestoId); 
        Task<Contrato> AgregarContrato(Contrato contrato);
    }
}
