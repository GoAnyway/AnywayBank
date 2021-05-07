using AutoMapper;
using Database.DbContexts;
using Database.Entities.Identity;
using DataManager.BaseRepositories;
using Models.InternalModels.EntityModels.Identity;

namespace DataManager.Repositories.PersonRepositories
{
    public class PersonRepository : BaseRepository<Person, PersonModel>, IPersonRepository
    {
        public PersonRepository(AnywayBankDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }
    }
}