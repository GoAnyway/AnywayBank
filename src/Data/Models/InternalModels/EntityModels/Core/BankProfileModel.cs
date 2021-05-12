using System.Collections.Generic;
using Data.Models.InternalModels.BaseEntityModels;

namespace Data.Models.InternalModels.EntityModels.Core
{
    public class BankProfileModel : BaseEntityModel
    {
        public ICollection<BankAccountModel> BankAccounts { get; set; } = new List<BankAccountModel>();
    }
}