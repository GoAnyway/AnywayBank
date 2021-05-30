using System;

namespace IdentityCore.Services.UserSecurity.PasswordSecretGenerators
{
    public class PasswordSecretGenerator : IPasswordSecretGenerator
    {
        public string GenerateSecret() => 
            $"{Guid.NewGuid():N}{DateTime.UtcNow.Millisecond}";
    }
}