using System;
using Models.InternalModels.BaseEntityModels;

namespace Models.InternalModels.EntityModels.Identity
{
    public class UserModel : BaseEntityModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationTime { get; set; }

        public PersonModel Person { get; set; }
    }
}