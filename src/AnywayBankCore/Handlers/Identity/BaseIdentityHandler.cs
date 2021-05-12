using System.Threading.Tasks;
using Data.Models.InternalModels.EntityModels.Identity;
using Data.Models.UtilModels;
using DataManager.Repositories.PersonRepositories;

namespace AnywayBankCore.Handlers.Identity
{
    public abstract class BaseIdentityHandler
    {
        protected readonly IPersonRepository PersonRepository;

        protected BaseIdentityHandler(IPersonRepository personRepository)
        {
            PersonRepository = personRepository;
        }

        protected virtual async Task<ResultModel<PersonModel>> TryGetPerson(string username) =>
            await PersonRepository.GetAsync<PersonModel>(_ => _.User.Username == username);
    }
}