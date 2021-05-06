using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataManager.BaseUnitsOfWork
{
    public abstract class BaseUnitOfWork<TDbContext> : IUnitOfWork
        where TDbContext : DbContext
    {
        protected readonly TDbContext Context;

        protected BaseUnitOfWork(TDbContext context)
        {
            Context = context;
        }

        public int SaveChanges() => 
            Context.SaveChanges();

        public async Task<int> SaveChangesAsync() => 
            await Context.SaveChangesAsync();
    }
}