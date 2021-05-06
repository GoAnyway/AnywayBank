using System.Threading.Tasks;

namespace DataManager.BaseUnitsOfWork
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
