using Database.DbContexts;
using DataManager.BaseUnitsOfWork;
using DataManager.Repositories.PersonRepositories;
using DataManager.Repositories.UserRepositories;

namespace DataManager.UnitsOfWork.AnywayBankUnitsOfWork
{
    public class AnywayBankUnitOfWork : BaseUnitOfWork<AnywayBankDbContext>, IAnywayBankUnitOfWork
    {
        public AnywayBankUnitOfWork(AnywayBankDbContext context, 
            IUserRepository userRepository, 
            IPersonRepository personRepository) 
            : base(context)
        {
            UserRepository = userRepository;
            PersonRepository = personRepository;
        }

        public IUserRepository UserRepository { get; }
        public IPersonRepository PersonRepository { get; }
    }
}
