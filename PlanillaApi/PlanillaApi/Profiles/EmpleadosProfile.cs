using AutoMapper;
using PlanillaApi.Core;
using PlanillaApi.Entities;
using PlanillaApi.Resources;

namespace PlanillaApi.Profiles
{
    public class EmpleadosProfile : Profile
    {
        public EmpleadosProfile()
        {
            CreateMap<ContratoResult, ApiResult<ContratoResultType, EmpleadoResource>>();
            CreateMap<Empleado, EmpleadoResource>();
            CreateMap<Contrato, ContratoResource>();
            
            CreateMap<NuevoEmpleado, Empleado>()
                .ForMember(nc => nc.Contratos, dest => dest.Ignore())
                .AfterMap((nuevoEmpleado, empleado) =>
                {
                    empleado.Contratos.Add(new Contrato 
                    {
                        Bonificacion = nuevoEmpleado.Bonificacion,
                        Empleado = empleado,
                        FechaInicio = nuevoEmpleado.FechaInicioContrato,
                        PuestoId = nuevoEmpleado.PuestoId,
                        SalarioBase = nuevoEmpleado.SalarioBase
                    });
                });
        }
    }
}
