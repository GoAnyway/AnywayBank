using System;
using Data.Models.InternalModels.BaseEntityModels;
using Data.Models.InternalModels.EntityModels.Core;

namespace Data.Models.InternalModels.EntityModels.Identity
{
    public class PersonModel : BaseEntityModel
    {
        public PersonModel()
        {
        }

        public PersonModel(UserModel user)
        {
            User = user;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public UserModel User { get; set; }
        public BankProfileModel BankProfile { get; set; }
    }
}