using Database.Entities.Identity;
using DataManager.BaseRepositories;
using Models.InternalModels.EntityModels.Identity;

namespace DataManager.Repositories.UserRepositories
{
    public interface IUserRepository : IRepository<User, UserModel>
    {
    }
}