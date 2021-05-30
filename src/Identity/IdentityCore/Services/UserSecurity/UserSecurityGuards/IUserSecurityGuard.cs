using Data.Models.EntityModels;

namespace IdentityCore.Services.UserSecurity.UserSecurityGuards
{
    public interface IUserSecurityGuard
    {
        void SecureUser(UserModel user);
        bool ComparePasswords(UserModel userToCheck, UserModel userFromDb);
    }
}