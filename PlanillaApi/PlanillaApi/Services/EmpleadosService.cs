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

        public async Task<ContratoResult> CrearContrato(Contrato contrato)
        {
            var existePlazaDisponible = await _empleadosRepository.ExistePlazaDisponible(contrato.PuestoId);
            if (!existePlazaDisponible) return ContratoResult.NoExistePlazaDisponible();

            var puesto = await _empleadosRepository.ObtenerPuestoPorId(contrato.PuestoId);
            if (contrato.SalarioBase > puesto.TechoSalarial) return ContratoResult.ExcedeTechoSalarial(puesto.TechoSalarial);

            contrato = await _empleadosRepository.AgregarContrato(contrato);
            await _unitOfWork.CompleteAsync();

            return ContratoResult.CreadoConExisto(contrato);
        }
    }
}
