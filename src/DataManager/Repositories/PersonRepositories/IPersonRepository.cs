using Database.Entities.Identity;
using DataManager.BaseRepositories;
using Models.InternalModels.EntityModels.Identity;

namespace DataManager.Repositories.PersonRepositories
{
    public interface IPersonRepository : IRepository<Person, PersonModel>
    {
    }
}