using Database.DbContexts;
using Database.Entities.Identity;
using DataManager.BaseRepositories;

namespace DataManager.Repositories.UserRepositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AnywayBankDbContext context) 
            : base(context)
        {
        }
    }
}