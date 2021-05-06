using Database.DbContexts;
using DataManager.BaseUnitsOfWork;
using DataManager.Repositories.UserRepositories;

namespace DataManager.UnitsOfWork.AnywayBankUnitsOfWork
{
    public class AnywayBankUnitOfWork : BaseUnitOfWork<AnywayBankDbContext>, IAnywayBankUnitOfWork
    {
        public AnywayBankUnitOfWork(AnywayBankDbContext context, IUserRepository userRepository) 
            : base(context)
        {
            UserRepository = userRepository;
        }

        public IUserRepository UserRepository { get; }
    }
}
