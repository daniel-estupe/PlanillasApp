using AutoMapper;
using PlanillaApi.Entities;
using PlanillaApi.Resources;

namespace PlanillaApi.Profiles
{
    public class EmpleadosProfile : Profile
    {
        public EmpleadosProfile()
        {
            CreateMap<Empleado, EmpleadoResource>();
            CreateMap<Contrato, ContratoResource>();
        }
    }
}
