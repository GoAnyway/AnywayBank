using AutoMapper;
using Database.DbContexts;
using Database.Entities.Identity;
using DataManager.BaseRepositories;
using Models.InternalModels.EntityModels.Identity;

namespace DataManager.Repositories.UserRepositories
{
    public class UserRepository : BaseRepository<User, UserModel>, IUserRepository
    {
        public UserRepository(AnywayBankDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}