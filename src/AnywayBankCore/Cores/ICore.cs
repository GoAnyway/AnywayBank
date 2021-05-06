using AnywayBankCore.Services.Identity;

namespace AnywayBankCore.Cores
{
    public interface ICore
    {
        public IIdentityService IdentityService { get; }
    }
}