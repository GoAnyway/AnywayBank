using System;
using System.ComponentModel.DataAnnotations.Schema;
using Database.BaseEntities;
using Database.Entities.Core.Bank.Enums;

namespace Database.Entities.Core.Bank
{
    public class BankAccount : BaseEntity
    {
        public BankAccountType Type { get; set; }
        public long Number { get; set; }
        [Column(TypeName = "decimal(18,4)")] public decimal Balance { get; set; }
        [Column(TypeName = "decimal(18,4)")] public decimal OverdraftLimit { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime EndTime { get; set; }

        [ForeignKey(nameof(BankProfile))] public Guid? BankProfileId { get; set; }
        public virtual BankProfile BankProfile { get; set; }
    }
}