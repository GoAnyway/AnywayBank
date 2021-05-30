using System.ComponentModel.DataAnnotations;
using Data.BaseRequests;
using Data.Models.EntityModels;

namespace Data.Requests
{
    public class AuthorizationRequest : IIdentityRequest<UserModel>
    {
        [Required] public string Username { get; set; }

        [Required] public string Password { get; set; }
    }
}