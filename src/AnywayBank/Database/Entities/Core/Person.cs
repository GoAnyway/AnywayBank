using System;
using CommonDatabase.BaseEntities;
using Database.Entities.Core.Bank;

namespace Database.Entities.Core
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public virtual BankProfile BankProfile { get; set; }
    }
}