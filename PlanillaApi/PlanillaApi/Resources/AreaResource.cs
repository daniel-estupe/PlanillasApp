
namespace PlanillaApi.Resources
{
    public class AreaResource
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = default!;
        public ICollection<PuestoResource> Puestos { get; set; } = new HashSet<PuestoResource>();
    }
}
