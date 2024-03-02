namespace PlanillaApi.Entities
{
    public class Puesto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = default!;
        public decimal TechoSalarial { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; } = default!;
        public bool Habilitado { get; set; }
        public int PlazasHabilitadas { get; set; }

        public ICollection<Contrato> Contratos { get; set; } = new HashSet<Contrato>();
    }
}
