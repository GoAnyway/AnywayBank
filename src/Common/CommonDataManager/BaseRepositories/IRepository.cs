using CommonData.UtilModels.ErrorModels;
using CommonDatabase.BaseEntities;
using CommonDataManager.BaseUnitsOfWork;

namespace CommonDataManager.BaseRepositories
{
    public interface IRepository<TEntity, TError> : IRepositoryCommon<TEntity, TError>,
        IRepositorySync<TEntity, TError>, IRepositoryAsync<TEntity, TError>, IUnitOfWork
        where TEntity : BaseEntity
        where TError : BaseErrorModel
    {
    }
}