using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanillaApi.Core;
using PlanillaApi.Entities;
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

        [HttpGet("{id}")]
        public async Task<EmpleadoResource> ObtenerEmpleado(int id)
        {
            var data = await empleadosService.GetById(id);
            return mapper.Map<EmpleadoResource>(data);
        }

        [HttpPost]
        public async Task<ApiResult<ContratoResultType, EmpleadoResource>> CrearEmpleado(NuevoEmpleado nuevoEmpleado)
        {
            var empleado = mapper.Map<Empleado>(nuevoEmpleado);
            var result = await empleadosService.CrearContrato(empleado);
            var contratoResource = mapper.Map<ApiResult<ContratoResultType, EmpleadoResource>>(result);
            return contratoResource;
        }

        [HttpPut("{id}")]
        public async Task<ApiResult<ContratoResultType, EmpleadoResource>> EditarEmpleado(int id, EdicionEmpleado edicionEmpleado)
        {
            var empleado = await empleadosService.GetById(id);
            empleado = mapper.Map(edicionEmpleado, empleado);
            var result = await empleadosService.EditarEmpleado(empleado);
            var contratoResource = mapper.Map<ApiResult<ContratoResultType, EmpleadoResource>>(result);
            return contratoResource;
        }
    }
}
