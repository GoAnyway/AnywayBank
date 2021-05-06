using System;
using System.Threading.Tasks;
using Database.BaseEntities;
using Models.UtilModels;

namespace DataManager.BaseRepositories
{
    public interface IRepositoryCommon<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
        where TKey : struct, IEquatable<TKey>
    {
        void Add(TEntity entity);
        Task<ResultModel<TEntity>> Update(TEntity entity);
        Task<ResultModel<object>> Remove(TEntity entity);
    }
}