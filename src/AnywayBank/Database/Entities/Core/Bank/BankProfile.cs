using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CommonDatabase.BaseEntities;

namespace Database.Entities.Core.Bank
{
    public class BankProfile : BaseEntity
    {
        public virtual ICollection<BankAccount> BankAccounts { get; set; }

        [ForeignKey(nameof(Person))] public Guid? PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}