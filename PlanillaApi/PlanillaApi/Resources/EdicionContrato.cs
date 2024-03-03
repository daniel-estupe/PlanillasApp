namespace PlanillaApi.Resources
{
    public class EdicionContrato
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public decimal SalarioBase { get; set; }
        public decimal Bonificacion { get; set; }
    }
}
