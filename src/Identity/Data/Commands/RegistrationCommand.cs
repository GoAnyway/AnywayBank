using System.ComponentModel.DataAnnotations;
using Data.BaseRequests;
using Data.Models.EntityModels;

namespace Data.Commands
{
    public class RegistrationCommand : IIdentityRequest<UserModel>
    {
        [Required] [EmailAddress] public string Email { get; set; }

        [Required] public string Username { get; set; }

        [Required] public string Password { get; set; }

        [Required] public string PasswordConfirmation { get; set; }
    }
}