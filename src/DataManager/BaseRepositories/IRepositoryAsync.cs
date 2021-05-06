using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Database.BaseEntities;
using Models.UtilModels;

namespace DataManager.BaseRepositories
{
    public interface IRepositoryAsync<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
        where TKey : struct, IEquatable<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = true);
        Task<ResultModel<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = true);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
    }
}