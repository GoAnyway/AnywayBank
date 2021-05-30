namespace IdentityCore.Services.UserSecurity.PasswordSecretGenerators
{
    public interface IPasswordSecretGenerator
    {
        string GenerateSecret();
    }
}