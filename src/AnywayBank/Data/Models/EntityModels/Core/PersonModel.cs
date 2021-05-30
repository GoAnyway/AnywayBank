using System;
using CommonData.BaseEntityModels;

namespace Data.Models.EntityModels.Core
{
    public class PersonModel : BaseEntityModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public BankProfileModel BankProfile { get; set; } = new();
    }
}