using System;
using Data.Models.InternalModels.BaseEntityModels;

namespace Data.Models.InternalModels.EntityModels.Identity
{
    public class UserModel : BaseEntityModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationTime { get; set; }
    }
}