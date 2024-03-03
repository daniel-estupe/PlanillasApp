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

            CreateMap<EdicionEmpleado, Empleado>()
                .ForMember(e => e.Contratos, dest => dest.Ignore())
                .AfterMap((edicionEmpleado, empleado) =>
                {
                    var contrato = empleado.Contratos.FirstOrDefault(c => c.Id == edicionEmpleado.Contrato.Id);
                    if (contrato == null) return;
                    contrato.Bonificacion = edicionEmpleado.Contrato.Bonificacion;
                    contrato.FechaInicio = edicionEmpleado.Contrato.FechaInicio;
                    contrato.FechaFinalizacion = edicionEmpleado.Contrato.FechaFinalizacion;
                    contrato.SalarioBase = edicionEmpleado.Contrato.SalarioBase;
                });

            CreateMap<EdicionContrato, Contrato>();

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
