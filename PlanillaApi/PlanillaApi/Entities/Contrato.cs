namespace PlanillaApi.Entities
{
    public class Contrato
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public int PuestoId { get; set; }
        public decimal SalarioBase { get; set; }
        public decimal Bonificacion { get; set; }

        public Empleado Empleado { get; set; } = default!;
        public Puesto Puesto { get; set; } = default!;
    }
}
