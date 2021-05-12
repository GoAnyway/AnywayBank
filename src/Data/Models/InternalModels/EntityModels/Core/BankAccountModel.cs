using System;
using Data.Models.InternalModels.BaseEntityModels;
using Data.Models.InternalModels.EntityModels.Core.Enums;

namespace Data.Models.InternalModels.EntityModels.Core
{
    public class BankAccountModel : BaseEntityModel
    {
        public BankAccountType Type { get; set; }
        public long Number { get; set; }
        public decimal Balance { get; set; }
        public decimal OverdraftLimit { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}