using PlanillaApi.Entities;

namespace PlanillaApi.Core
{
    public class ContratoResult : ApiResult<ContratoResultType, Empleado>
    {
        public static ContratoResult CreadoConExisto(Empleado empleado) =>
            new() { Codigo = ContratoResultType.Success, Mensaje = "Contrato creado con éxito.", Data = empleado };
        public static ContratoResult GuardadoConExisto(Empleado empleado) =>
            new() { Codigo = ContratoResultType.Success, Mensaje = "Registro guardado con éxito.", Data = empleado };
        public static ContratoResult NoExistePlazaDisponible() =>
            new() { Codigo = ContratoResultType.NoExistePlazaDisponible, Mensaje = "Las plazas habilitadas para el puesto ya han sido ocupadas." };

        public static ContratoResult ExcedeTechoSalarial(decimal techoSalarial) =>
            new() { Codigo = ContratoResultType.ExcedeTechoSalarial, Mensaje = "El contrato excede el techo salarial de Q." + techoSalarial.ToString("#.##") + "." };
    }

    public enum ContratoResultType
    {
        Success = 0,
        ExcedeTechoSalarial = 1,
        NoExistePlazaDisponible = 2
    }
}
