using AnywayBankCore.Services.Identity;

namespace AnywayBankCore.Cores
{
    public class Core : ICore
    {
        public Core(IIdentityService identityService)
        {
            IdentityService = identityService;
        }

        public IIdentityService IdentityService { get; }
    }
}