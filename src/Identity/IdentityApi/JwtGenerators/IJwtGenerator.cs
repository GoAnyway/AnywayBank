using Data.Models.EntityModels;

namespace IdentityApi.JwtGenerators
{
    public interface IJwtGenerator
    {
        string GenerateJwtToken(UserModel user);
    }
}