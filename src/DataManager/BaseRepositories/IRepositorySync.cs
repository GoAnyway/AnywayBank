using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Database.BaseEntities;
using Models.InternalModels.BaseEntityModels;
using Models.UtilModels;

namespace DataManager.BaseRepositories
{
    public interface IRepositorySync<TEntity, TModel, TKey>
        where TEntity : class, IEntity<TKey>, new()
        where TModel : IEntityModel<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        IEnumerable<TModel> GetAll(Expression<Func<TModel, bool>> predicate, bool asNoTracking = true);
        ResultModel<TModel> Get(Expression<Func<TModel, bool>> predicate, bool asNoTracking = true);
        bool Any(Expression<Func<TModel, bool>> predicate);
    }
}