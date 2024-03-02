namespace PlanillaApi.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
