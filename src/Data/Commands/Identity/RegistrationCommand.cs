using System.ComponentModel.DataAnnotations;
using Data.Models.InternalModels.EntityModels.Identity;
using Data.Models.UtilModels;
using MediatR;

namespace Data.Commands.Identity
{
    public class RegistrationCommand : IRequest<ResultModel<PersonModel>>
    {
        [Required] [EmailAddress] public string Email { get; set; }

        [Required] public string Username { get; set; }

        [Required] public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords mismatch.")]
        public string PasswordConfirmation { get; set; }
    }
}