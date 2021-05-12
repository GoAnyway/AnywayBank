using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data.Models.InternalModels.BaseEntityModels;
using Data.Models.UtilModels;
using Database.BaseEntities;

namespace DataManager.BaseRepositories
{
    public interface IRepositoryAsync<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
        where TKey : struct, IEquatable<TKey>
    {
        Task<IEnumerable<TModel>> GetAllAsync<TModel>(Expression<Func<TModel, bool>> predicate,
            bool asNoTracking = true)
            where TModel : class, IEntityModel<TKey>, new();

        Task<ResultModel<TModel>> GetAsync<TModel>(Expression<Func<TModel, bool>> predicate, bool asNoTracking = true)
            where TModel : class, IEntityModel<TKey>, new();

        Task<bool> AnyAsync<TModel>(Expression<Func<TModel, bool>> predicate)
            where TModel : class, IEntityModel<TKey>, new();
    }
}