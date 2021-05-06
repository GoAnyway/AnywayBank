using System.Threading.Tasks;
using Models.EntityModels.Identity;
using Models.UtilModels;

namespace AnywayBankCore.Services.Identity
{
    public interface IIdentityService
    {
        Task<ResultModel<PersonModel>> RegisterAsync(UserModel model);
        Task<ResultModel<PersonModel>> AuthorizeAsync(UserModel model);
    }
}