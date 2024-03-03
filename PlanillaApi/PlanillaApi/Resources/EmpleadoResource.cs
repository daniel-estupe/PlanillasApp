namespace PlanillaApi.Resources
{
    public class EmpleadoResource
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = default!;
        public string Apellidos { get; set; } = default!;
        public string Genero { get; set; } = default!;
        public string EstadoCivil { get; set; } = default!;
        public DateTime FechaNacimiento { get; set; }
        // public int Edad { get; set; } calculado
        public string CUI { get; set; } = default!;
        public string NIT { get; set; } = default!;
        public string? Pasaporte { get; set; }
        public string? AfiliacionIGSS { get; set; }
        public string? AfiliacionIRTRA { get; set; }
        public DateTime? FechaAfiliacionIRTRA { get; set; }

        public ICollection<ContratoResource> Contratos { get; set; } = new HashSet<ContratoResource>();
    }
}
