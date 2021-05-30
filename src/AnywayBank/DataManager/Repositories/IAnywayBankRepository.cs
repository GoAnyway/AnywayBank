using CommonData.UtilModels.ErrorModels;
using CommonDatabase.BaseEntities;
using CommonDataManager.BaseRepositories;

namespace DataManager.Repositories
{
    public interface IAnywayBankRepository<TEntity> : IRepository<TEntity, DefaultErrorModel>
        where TEntity : BaseEntity
    {
    }
}