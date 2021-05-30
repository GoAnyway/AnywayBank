using System;
using CommonData.BaseEntityModels;

namespace Data.Models.EntityModels
{
    public class UserModel : BaseEntityModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationTime { get; set; }
    }
}