namespace PlanillaApi.Resources
{
    public class NuevoContrato
    {
        public DateTime FechaInicio { get; set; }
        public int PuestoId { get; set; }
        public decimal SalarioBase { get; set; }
        public decimal Bonificacion { get; set; }
    }
}
