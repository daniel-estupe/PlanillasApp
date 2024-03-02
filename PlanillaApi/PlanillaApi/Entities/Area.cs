namespace PlanillaApi.Entities
{
    public class Area
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = default!;
        public int? ReportaAId { get; set; }
        public Area? ReportaA { get; set; }
        public ICollection<Area> AreasSubordinadas { get; set; } = new HashSet<Area>();
        public ICollection<Puesto> Puestos { get; set; } = new HashSet<Puesto>();
    }
}
