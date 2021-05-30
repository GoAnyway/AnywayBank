using Data.Models.EntityModels;
using IdentityCore.Services.UserSecurity.PasswordHashers;
using IdentityCore.Services.UserSecurity.PasswordSecretGenerators;

namespace IdentityCore.Services.UserSecurity.UserSecurityGuards
{
    public class UserSecurityGuard : IUserSecurityGuard
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IPasswordSecretGenerator _passwordSecretGenerator;

        public UserSecurityGuard(IPasswordHasher passwordHasher, IPasswordSecretGenerator passwordSecretGenerator)
        {
            _passwordHasher = passwordHasher;
            _passwordSecretGenerator = passwordSecretGenerator;
        }

        public void SecureUser(UserModel user)
        {
            var secret = _passwordSecretGenerator.GenerateSecret();
            var strongPassword = $"{user.Password}{secret}";
            var hashedPassword = _passwordHasher.HashPassword(strongPassword);

            user.Password = hashedPassword;
            user.PasswordSecret = secret;
        }

        public bool ComparePasswords(UserModel userToCheck, UserModel userFromDb)
        {
            var password = $"{userToCheck.Password}{userFromDb.PasswordSecret}";
            var hashedPassword = _passwordHasher.HashPassword(password);

            return hashedPassword == userFromDb.Password;
        }
    }
}