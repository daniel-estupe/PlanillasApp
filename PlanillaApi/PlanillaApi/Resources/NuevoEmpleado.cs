namespace PlanillaApi.Resources
{
    public class NuevoEmpleado
    {
        public string Nombres { get; set; } = default!;
        public string Apellidos { get; set; } = default!;
        public string Genero { get; set; } = default!;
        public string EstadoCivil { get; set; } = default!;
        public DateTime FechaNacimiento { get; set; }
        public string CUI { get; set; } = default!;
        public string NIT { get; set; } = default!;
        public string? Pasaporte { get; set; }
        public string? AfiliacionIGSS { get; set; }
        public string? AfiliacionIRTRA { get; set; }
        public DateTime? FechaAfiliacionIRTRA { get; set; }

        public DateTime FechaInicioContrato { get; set; }
        public int PuestoId { get; set; }
        public decimal SalarioBase { get; set; }
        public decimal Bonificacion { get; set; }

    }
}
