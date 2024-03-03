using AutoMapper;
using PlanillaApi.Entities;
using PlanillaApi.Resources;

namespace PlanillaApi.Profiles
{
    public class CatalogosProfile : Profile
    {
        public CatalogosProfile()
        {
            CreateMap<Area, AreaResource>();
            CreateMap<Puesto, PuestoResource>();
        }
    }
}
