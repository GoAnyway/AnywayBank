using System.ComponentModel.DataAnnotations;
using Data.Models.InternalModels.EntityModels.Identity;
using Data.Models.UtilModels;
using MediatR;

namespace Data.Requests.Identity
{
    public class AuthorizationRequest : IRequest<ResultModel<PersonModel>>
    {
        [Required] public string Username { get; set; }

        [Required] public string Password { get; set; }
    }
}