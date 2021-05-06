using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Database.BaseEntities;
using Models.UtilModels;

namespace DataManager.BaseRepositories
{
    public interface IRepositorySync<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
        where TKey : struct, IEquatable<TKey>
    {
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = true);
        ResultModel<TEntity> Get(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = true);
        bool Any(Expression<Func<TEntity, bool>> predicate);
    }
}