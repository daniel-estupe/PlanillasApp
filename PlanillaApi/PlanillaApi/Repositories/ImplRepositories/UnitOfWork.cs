using PlanillaApi.Core;
using PlanillaApi.Data;

namespace PlanillaApi.Repositories.ImplRepositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
