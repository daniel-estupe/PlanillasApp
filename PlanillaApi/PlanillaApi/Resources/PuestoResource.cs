namespace PlanillaApi.Resources
{
    public class PuestoResource
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = default!;
        public AreaResource Area { get; set; } = default!;
    }
}
