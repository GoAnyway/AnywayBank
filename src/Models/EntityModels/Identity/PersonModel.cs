using System;
using Models.BaseEntityModels;
using Models.EntityModels.Core;

namespace Models.EntityModels.Identity
{
    public class PersonModel : BaseEntityModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public UserModel User { get; set; }
        public BankProfileModel BankProfile { get; set; }
    }
}
