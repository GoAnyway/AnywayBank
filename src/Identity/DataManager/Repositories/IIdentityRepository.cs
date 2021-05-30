using CommonData.UtilModels.ErrorModels;
using CommonDatabase.BaseEntities;
using CommonDataManager.BaseRepositories;

namespace DataManager.Repositories
{
    public interface IIdentityRepository<TEntity> : IRepository<TEntity, DefaultErrorModel>
        where TEntity : BaseEntity
    {
    }
}