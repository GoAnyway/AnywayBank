using System;
using Database.BaseEntities;
using Models.UtilModels;

namespace DataManager.BaseRepositories
{
    public interface IRepositoryCommon<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
        where TKey : struct, IEquatable<TKey>
    {
        ResultModel<TEntity> Create(TEntity entity);
        ResultModel<TEntity> Update(TEntity entity);
        ResultModel<object> Remove(TEntity entity);
    }
}