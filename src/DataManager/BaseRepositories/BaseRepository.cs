using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Database.BaseEntities;
using Database.DbContexts;
using Microsoft.EntityFrameworkCore;
using Models.UtilModels;

namespace DataManager.BaseRepositories
{
    public abstract class BaseRepository<TEntity> : BaseRepository<TEntity, Guid, BankDbContext>
        where TEntity : class, IEntity<Guid>, new()
    {
        protected BaseRepository(BankDbContext context)
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

        public virtual ResultModel<TEntity> Create(TEntity entity)
        {
            var result = new ResultModel<TEntity>(true);

            var alreadyCreated = Any(_ => _.Id.Equals(entity.Id));
            if (!alreadyCreated)
            {
                result.Data = RepoDbSet.Add(entity).Entity;
            }
            else
            {
                result.Success = false;
                result.Error = new ErrorModel(1001, "Entity already exists.");
            }

            return result;
        }

        public virtual ResultModel<TEntity> Update(TEntity entity)
        {
            var result = new ResultModel<TEntity>(true);

            var neededEntity = Get(_ => _.Id.Equals(entity.Id));
            if (neededEntity.Success)
            {
                result.Data = RepoDbSet.Update(neededEntity.Data).Entity;
            }
            else
            {
                result.Success = false;
                result.Error = neededEntity.Error;
            }

            return result;
        }

        public virtual ResultModel<object> Remove(TEntity entity)
        {
            var result = new ResultModel<object>(true);

            var entityToDelete = Get(_ => _.Id.Equals(entity.Id));
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

        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = true) =>
            asNoTracking
                ? QuerySet(predicate).AsNoTracking().ToList()
                : QuerySet(predicate).ToList();

        public virtual ResultModel<TEntity> Get(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = true)
        {
            var result = new ResultModel<TEntity>(true);

            var entity = asNoTracking
                ? RepoDbSet.AsNoTracking().FirstOrDefault(predicate)
                : RepoDbSet.FirstOrDefault(predicate);

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

        public virtual bool Any(Expression<Func<TEntity, bool>> predicate) =>
            RepoDbSet.Any(predicate);

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