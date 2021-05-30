using System.ComponentModel.DataAnnotations;
using Data.Models.InternalModels.EntityModels.Identity;
using Data.Models.UtilModels;
using Data.Models.UtilModels.ErrorModels;
using MediatR;

namespace Data.Requests.Identity
{
    public class AuthorizationRequest : IRequest<OneOfModel<PersonModel, DefaultErrorModel>>
    {
        [Required] public string Username { get; set; }

        [Required] public string Password { get; set; }
    }
}