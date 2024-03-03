using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanillaApi.Entities;
using PlanillaApi.Repositories.Interfaces;
using PlanillaApi.Resources;

namespace PlanillaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogosController : ControllerBase
    {
        private readonly ICatalogosRepository catalogosRepository;
        private readonly IMapper mapper;

        public CatalogosController(ICatalogosRepository catalogosRepository, IMapper mapper) 
        {
            this.catalogosRepository = catalogosRepository;
            this.mapper = mapper;
        }

        [HttpGet("puestos-disponibles-por-area")]
        public async Task<IEnumerable<AreaResource>> AreasConPuestosDisponibles()
        {
            var data = await catalogosRepository.ObtenerAreasConPuestosDisponibles();
            return mapper.Map<IEnumerable<AreaResource>>(data);
        }
    }
}
