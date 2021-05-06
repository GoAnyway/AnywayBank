using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Database.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Models.UtilModels;

namespace DataManager.BaseRepositories
{
    public abstract class BaseRepository<TEntity, TDbContext> : BaseRepository<TEntity, Guid, TDbContext>
        where TEntity : class, IEntity<Guid>, new()
        where TDbContext : DbContext
    {
        protected BaseRepository(TDbContext context)
            : base(context)
        {
        }
    }

    public abstract class BaseRepository<TEntity, TKey, TDbContext> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
        where TKey : struct, IEquatable<TKey>
        where TDbContext : DbContext
    {
        protected readonly TDbContext Context;
        protected readonly DbSet<TEntity> RepoDbSet;

        protected BaseRepository(TDbContext context)
        {
            Context = context;
            RepoDbSet = Context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity) => RepoDbSet.Add(entity);

        public virtual async Task<ResultModel<TEntity>> Update(TEntity entity)
        {
            var result = new ResultModel<TEntity>(true);

            var neededEntity = await GetAsync(_ => _.Id.Equals(entity.Id));
            if (neededEntity.Success)
            {
                RepoDbSet.Update(neededEntity.Data);
            }
            else
            {
                result.Success = false;
                result.Error = neededEntity.Error;
            }

            return result;
        }

        public virtual async Task<ResultModel<object>> Remove(TEntity entity)
        {
            var result = new ResultModel<object>(true);

            var entityToDelete = await GetAsync(_ => _.Id.Equals(entity.Id));
            if (entityToDelete.Success)
            {
                RepoDbSet.Remove(entityToDelete.Data);
            }
            else
            {
                result.Success = false;
                result.Error = entityToDelete.Error;
            }

            return result;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate,
            bool asNoTracking = true) =>
            asNoTracking
                ? await QuerySet(predicate).AsNoTracking().ToListAsync()
                : await QuerySet(predicate).ToListAsync();

        public virtual async Task<ResultModel<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate,
            bool asNoTracking = true)
        {
            var result = new ResultModel<TEntity>(true);

            var entity = asNoTracking
                ? await RepoDbSet.AsNoTracking().FirstOrDefaultAsync(predicate)
                : await RepoDbSet.FirstOrDefaultAsync(predicate);

            if (entity != null)
            {
                result.Data = entity;
            }
            else
            {
                result.Success = false;
                result.Error = new ErrorModel(1001, "Entity not found.");
            }

            return result;
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate) =>
            await RepoDbSet.AnyAsync(predicate);

        private IQueryable<TEntity> QuerySet(Expression<Func<TEntity, bool>> predicate = null) =>
            predicate != null ? RepoDbSet.Where(predicate) : RepoDbSet;
    }
}