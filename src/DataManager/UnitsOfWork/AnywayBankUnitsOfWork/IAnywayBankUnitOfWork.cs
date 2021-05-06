using DataManager.BaseUnitsOfWork;
using DataManager.Repositories.UserRepositories;

namespace DataManager.UnitsOfWork.AnywayBankUnitsOfWork
{
    public interface IAnywayBankUnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
    }
}