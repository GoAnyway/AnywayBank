using Database.DbContexts;
using DataManager.BaseUnitsOfWork;

namespace DataManager.UnitsOfWork.AnywayBankUnitsOfWork
{
    public class AnywayBankUnitOfWork : BaseUnitOfWork<AnywayBankDbContext>, IAnywayBankUnitOfWork
    {
        public AnywayBankUnitOfWork(AnywayBankDbContext context) : base(context)
        {
        }
    }
}
