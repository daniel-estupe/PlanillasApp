using PlanillaApi.Entities;

namespace PlanillaApi.Repositories.Interfaces
{
    public interface IEmpleadosRepository
    {
        Task<bool> ExistePlazaDisponible(int puestoId);
        Task<Puesto> ObtenerPuestoPorId(int puestoId); 
        void AgregarContrato(Contrato contrato);
        Task<IEnumerable<Empleado>> ObtenerEmpleados();
        Task<Empleado> ObtenerEmpleado(int id);
    }
}
