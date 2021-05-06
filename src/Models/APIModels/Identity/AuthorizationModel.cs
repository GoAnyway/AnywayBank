using System.ComponentModel.DataAnnotations;

namespace Models.APIModels.Identity
{
    public class AuthorizationModel
    {
        [Required] public string Username { get; set; }

        [Required] public string Password { get; set; }
    }
}