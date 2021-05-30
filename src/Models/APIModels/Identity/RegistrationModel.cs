using System.ComponentModel.DataAnnotations;

namespace Models.APIModels.Identity
{
    public class RegistrationModel
    {
        [Required] [EmailAddress] public string Email { get; set; }

        [Required] public string Username { get; set; }

        [Required] public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords mismatch.")]
        public string PasswordConfirmation { get; set; }
    }
}