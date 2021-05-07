using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Database.BaseEntities;
using Models.InternalModels.BaseEntityModels;
using Models.UtilModels;

namespace DataManager.BaseRepositories
{
    public interface IRepositoryAsync<TEntity, TModel, TKey>
        where TEntity : class, IEntity<TKey>, new()
        where TModel : class, IEntityModel<TKey>, new()
        where TKey : struct, IEquatable<TKey>
    {
        Task<IEnumerable<TModel>> GetAllAsync(Expression<Func<TModel, bool>> predicate, bool asNoTracking = true);
        Task<ResultModel<TModel>> GetAsync(Expression<Func<TModel, bool>> predicate, bool asNoTracking = true);
        Task<bool> AnyAsync(Expression<Func<TModel, bool>> predicate);
    }
}