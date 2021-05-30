using System.Security.Cryptography;
using System.Text;

namespace IdentityCore.Services.UserSecurity.PasswordHashers
{
    public class Sha256PasswordHasher : IPasswordHasher
    {
        private readonly SHA256 _sha256 = SHA256.Create();

        public string HashPassword(string password)
        {
            var inputBytes = Encoding.UTF8.GetBytes(password);
            var hashedBytes = _sha256.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            foreach (var @byte in hashedBytes)
            {
                sb.Append(@byte.ToString("X"));
            }

            return sb.ToString();
        }
    }
}