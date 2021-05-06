using System.Collections.Generic;
using Models.BaseEntityModels;
using Models.EntityModels.Identity;

namespace Models.EntityModels.Core
{
    public class BankProfileModel : BaseEntityModel
    {
        public ICollection<BankAccountModel> BankAccounts { get; set; } = new List<BankAccountModel>();

        public PersonModel Person { get; set; }
    }
}
