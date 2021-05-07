using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Database.BaseEntities;
using Database.DbContexts;
using Microsoft.EntityFrameworkCore;
using Models.InternalModels.BaseEntityModels;
using Models.UtilModels;

namespace DataManager.BaseRepositories
{
    public abstract class BaseRepository<TEntity, TModel> : BaseRepository<TEntity, TModel, Guid, AnywayBankDbContext>
        where TEntity : class, IEntity<Guid>, new()
        where TModel : IEntityModel<Guid>
    {
        protected BaseRepository(AnywayBankDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }

    public abstract class BaseRepository<TEntity, TModel, TKey, TDbContext> : IRepository<TEntity, TModel, TKey>
        where TEntity : class, IEntity<TKey>, new()
        where TModel : IEntityModel<TKey>
        where TKey : struct, IEquatable<TKey>
        where TDbContext : DbContext
    {
        protected readonly TDbContext Context;
        protected readonly IMapper Mapper;
        protected readonly DbSet<TEntity> RepoDbSet;

        protected BaseRepository(TDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
            RepoDbSet = Context.Set<TEntity>();
        }

        public virtual ResultModel<TModel> Create(TModel model)
        {
            var result = new ResultModel<TModel>(true);

            var alreadyCreated = Any(_ => _.Id.Equals(model.Id));
            if (!alreadyCreated)
            {
                var entity = Mapper.Map<TEntity>(model);
                entity = RepoDbSet.Add(entity).Entity;
                Mapper.Map(entity, model);
                result.Data = model;
            }
            else
            {
                result.Success = false;
                result.Error = new ErrorModel(1001, "Entity already exists.");
            }

            return result;
        }

        public virtual ResultModel<TModel> Update(TModel model)
        {
            var result = new ResultModel<TModel>(true);

            var entity = GetInternal(_ => _.Id.Equals(model.Id));
            if (entity.Success)
            {
                Mapper.Map(model, entity.Data);
                entity.Data = RepoDbSet.Update(entity.Data).Entity;
                Mapper.Map(entity.Data, model);
                result.Data = model;
            }
            else
            {
                result.Success = false;
                result.Error = entity.Error;
            }

            return result;
        }

        public virtual ResultModel<object> Remove(TModel model)
        {
            var result = new ResultModel<object>(true);

            var entityToDelete = GetInternal(_ => _.Id.Equals(model.Id));
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

        public virtual IEnumerable<TModel> GetAll(Expression<Func<TModel, bool>> predicate, bool asNoTracking = true) =>
            asNoTracking
                ? QuerySet(predicate)
                    .AsNoTracking()
                    .ProjectTo<TModel>(Mapper.ConfigurationProvider)
                    .ToList()
                : QuerySet(predicate)
                    .ProjectTo<TModel>(Mapper.ConfigurationProvider)
                    .ToList();

        public virtual ResultModel<TModel> Get(Expression<Func<TModel, bool>> predicate, bool asNoTracking = true)
        {
            var entity = GetInternal(predicate);

            return new ResultModel<TModel>(true)
            {
                Success = entity.Success,
                Data = Mapper.Map<TModel>(entity.Data),
                Error = entity.Error
            };
        }

        public virtual bool Any(Expression<Func<TModel, bool>> predicate) =>
            RepoDbSet.Any(MapPredicate(predicate));

        public virtual async Task<IEnumerable<TModel>> GetAllAsync(Expression<Func<TModel, bool>> predicate,
            bool asNoTracking = true) =>
            asNoTracking
                ? await QuerySet(predicate)
                    .AsNoTracking()
                    .ProjectTo<TModel>(Mapper.ConfigurationProvider)
                    .ToListAsync()
                : await QuerySet(predicate)
                    .ProjectTo<TModel>(Mapper.ConfigurationProvider)
                    .ToListAsync();

        public virtual async Task<ResultModel<TModel>> GetAsync(Expression<Func<TModel, bool>> predicate,
            bool asNoTracking = true)
        {
            var entity = await GetInternalAsync(predicate);

            return new ResultModel<TModel>(true)
            {
                Success = entity.Success,
                Data = Mapper.Map<TModel>(entity.Data), 
                Error = entity.Error
            };
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<TModel, bool>> predicate) =>
            await RepoDbSet.AnyAsync(MapPredicate(predicate));

        protected virtual ResultModel<TEntity> GetInternal(Expression<Func<TModel, bool>> predicate, bool asNoTracking = true)
        {
            var result = new ResultModel<TEntity>(true);

            var entity = asNoTracking
                ? RepoDbSet.AsNoTracking().FirstOrDefault(MapPredicate(predicate))
                : RepoDbSet.FirstOrDefault(MapPredicate(predicate));

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

        protected virtual async Task<ResultModel<TEntity>> GetInternalAsync(Expression<Func<TModel, bool>> predicate, bool asNoTracking = true)
        {
            var result = new ResultModel<TEntity>(true);

            var entity = asNoTracking
                ? await RepoDbSet.AsNoTracking().FirstOrDefaultAsync(MapPredicate(predicate))
                : await RepoDbSet.FirstOrDefaultAsync(MapPredicate(predicate));

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

        private IQueryable<TEntity> QuerySet(Expression<Func<TModel, bool>> predicate = null) =>
            predicate != null
                ? RepoDbSet.Where(MapPredicate(predicate))
                : RepoDbSet;

        private Expression<Func<TEntity, bool>> MapPredicate(Expression<Func<TModel, bool>> predicate) =>
            Mapper.Map<Expression<Func<TEntity, bool>>>(predicate);
    }
}