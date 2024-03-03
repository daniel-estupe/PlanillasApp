using PlanillaApi.Core;
using PlanillaApi.Entities;
using PlanillaApi.Repositories.Interfaces;
using PlanillaApi.Services.Interfaces;

namespace PlanillaApi.Services
{
    public class EmpleadosService : IEmpleadosService
    {
        private readonly IEmpleadosRepository _empleadosRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmpleadosService(IEmpleadosRepository empleadosRepository, IUnitOfWork unitOfWork) 
        {
            this._empleadosRepository = empleadosRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<ContratoResult> CrearContrato(Empleado empleado)
        {
            var contrato = empleado.Contratos.First();
            var existePlazaDisponible = await _empleadosRepository.ExistePlazaDisponible(contrato.PuestoId);
            if (!existePlazaDisponible) return ContratoResult.NoExistePlazaDisponible();

            var puesto = await _empleadosRepository.ObtenerPuestoPorId(contrato.PuestoId);
            if (contrato.SalarioBase > puesto.TechoSalarial) return ContratoResult.ExcedeTechoSalarial(puesto.TechoSalarial);

            _empleadosRepository.AgregarContrato(contrato);
            await _unitOfWork.CompleteAsync();

            empleado = await _empleadosRepository.ObtenerEmpleado(empleado.Id);
            
            return ContratoResult.CreadoConExisto(empleado);
        }

        public async Task<IEnumerable<Empleado>> GetAll()
        {
            return await _empleadosRepository.ObtenerEmpleados();
        }

        public async Task<Empleado> GetById(int id)
        {
            return await _empleadosRepository.ObtenerEmpleado(id);
        }
    }
}
