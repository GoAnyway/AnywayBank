using System;
using CommonData.BaseEntityModels;
using Data.Models.EntityModels.Core.Enums;

namespace Data.Models.EntityModels.Core
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