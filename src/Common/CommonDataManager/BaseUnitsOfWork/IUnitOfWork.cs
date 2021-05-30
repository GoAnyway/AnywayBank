using System.Threading.Tasks;

namespace CommonDataManager.BaseUnitsOfWork
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        Task BeginTransactionAsync();
        int Commit();
        Task<int> CommitAsync();
        void Rollback();
        Task RollbackAsync();
    }
}