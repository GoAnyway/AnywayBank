namespace IdentityCore.Services.UserSecurity.PasswordHashers
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}