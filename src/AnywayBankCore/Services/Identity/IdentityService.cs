using System;
using System.Threading.Tasks;
using AnywayBankCore.BaseServices;
using AutoMapper;
using Database.Entities.Identity;
using DataManager.UnitsOfWork.AnywayBankUnitsOfWork;
using Models.InternalModels.EntityModels.Identity;
using Models.UtilModels;

namespace AnywayBankCore.Services.Identity
{
    public class IdentityService : BaseService, IIdentityService
    {
        public IdentityService(IAnywayBankUnitOfWork unitOfWork, IMapper mapper) 
            : base(unitOfWork, mapper)
        {
        }

        public async Task<ResultModel<PersonModel>> RegisterAsync(UserModel model)
        {
            var result = new ResultModel<PersonModel>(false);

            var user = Mapper.Map<User>(model);
            user.RegistrationTime = DateTime.UtcNow;
            var userCreationResult = UnitOfWork.UserRepository.Create(user);
            if (!userCreationResult.Success)
            {
                result.Error = userCreationResult.Error;
                return result;
            }

            var person = new Person { User = user };
            var personCreationResult = UnitOfWork.PersonRepository.Create(person);
            if (!personCreationResult.Success)
            {
                result.Error = personCreationResult.Error;
                return result;
            }

            userCreationResult.Data.PersonId = personCreationResult.Data.Id;
            UnitOfWork.UserRepository.Update(userCreationResult.Data);
            await UnitOfWork.SaveChangesAsync();
            result.Success = true;
            result.Data = Mapper.Map<PersonModel>(personCreationResult.Data);

            return result;
        }

        public async Task<ResultModel<PersonModel>> AuthorizeAsync(UserModel model)
        {
            var result = new ResultModel<PersonModel>(true);

            var userSearchResult = await UnitOfWork.UserRepository.GetAsync(_ => _.Id == model.Id);
            if (userSearchResult.Success)
            {
                result.Data = Mapper.Map<PersonModel>(userSearchResult.Data.Person);
            }
            else
            {
                result.Success = false;
                result.Error = userSearchResult.Error;
            }

            return result;
        }
    }
}