using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanillaApi.Resources;
using PlanillaApi.Services.Interfaces;

namespace PlanillaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadosService empleadosService;
        private readonly IMapper mapper;

        public EmpleadosController(IEmpleadosService empleadosService, IMapper mapper) 
        {
            this.empleadosService = empleadosService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<EmpleadoResource>> ObtenerEmpleados()
        {
            var data = await empleadosService.GetAll();
            return mapper.Map<IEnumerable<EmpleadoResource>>(data);
        }
    }
}
