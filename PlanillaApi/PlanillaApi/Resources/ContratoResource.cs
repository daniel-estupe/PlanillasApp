namespace PlanillaApi.Resources
{
    public class ContratoResource
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public decimal SalarioBase { get; set; }
        public decimal Bonificacion { get; set; }

        public PuestoResource Puesto { get; set; } = default!;
    }
}
