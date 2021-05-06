using Database.DbContexts;
using Database.Entities.Identity;
using DataManager.BaseRepositories;

namespace DataManager.Repositories.PersonRepositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(AnywayBankDbContext context) 
            : base(context)
        {
        }
    }
}