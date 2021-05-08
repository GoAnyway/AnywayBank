using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Database.BaseEntities;
using Models.InternalModels.BaseEntityModels;
using Models.UtilModels;

namespace DataManager.BaseRepositories
{
    public interface IRepositorySync<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
        where TKey : struct, IEquatable<TKey>
    {
        IEnumerable<TModel> GetAll<TModel>(Expression<Func<TModel, bool>> predicate, bool asNoTracking = true)
            where TModel : class, IEntityModel<TKey>, new();
        ResultModel<TModel> Get<TModel>(Expression<Func<TModel, bool>> predicate, bool asNoTracking = true)
            where TModel : class, IEntityModel<TKey>, new();
        bool Any<TModel>(Expression<Func<TModel, bool>> predicate)
            where TModel : class, IEntityModel<TKey>, new();
    }
}