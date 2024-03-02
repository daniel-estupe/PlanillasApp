namespace PlanillaApi.Core
{
    public class ApiResult<T, R>
    {
        public T Codigo { get; set; } = default!;
        public string Mensaje { get; set; } = string.Empty;
        public R? Data { get; set; }
    }
}
