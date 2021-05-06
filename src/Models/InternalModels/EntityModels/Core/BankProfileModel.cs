using System.Collections.Generic;
using Models.InternalModels.BaseEntityModels;
using Models.InternalModels.EntityModels.Identity;

namespace Models.InternalModels.EntityModels.Core
{
    public class BankProfileModel : BaseEntityModel
    {
        public ICollection<BankAccountModel> BankAccounts { get; set; } = new List<BankAccountModel>();

        public PersonModel Person { get; set; }
    }
}
