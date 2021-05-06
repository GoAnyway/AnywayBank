using System;
using Models.InternalModels.BaseEntityModels;
using Models.InternalModels.EntityModels.Core.Enums;

namespace Models.InternalModels.EntityModels.Core
{
    public class BankAccountModel : BaseEntityModel
    {
        public BankAccountType Type { get; set; }
        public long Number { get; set; }
        public decimal Balance { get; set; }
        public decimal OverdraftLimit { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime EndTime { get; set; }

        public BankProfileModel BankProfile { get; set; }
    }
}
