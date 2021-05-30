using System.Collections.Generic;
using CommonData.BaseEntityModels;

namespace Data.Models.EntityModels.Core
{
    public class BankProfileModel : BaseEntityModel
    {
        public ICollection<BankAccountModel> BankAccounts { get; set; } = new List<BankAccountModel>();
    }
}