using System.Threading.Tasks;
using Models.APIModels.Identity;
using Models.InternalModels.EntityModels.Identity;
using Models.UtilModels;

namespace AnywayBankCore.Services.Identity
{
    public interface IIdentityService
    {
        Task<ResultModel<PersonModel>> RegisterAsync(RegistrationModel model);
        Task<ResultModel<PersonModel>> AuthorizeAsync(AuthorizationModel model);
    }
}