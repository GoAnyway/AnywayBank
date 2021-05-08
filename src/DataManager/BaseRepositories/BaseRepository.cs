using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Database.BaseEntities;
using Database.DbContexts;
using DataManager.BaseUnitsOfWork;
using Microsoft.EntityFrameworkCore;
using Models.InternalModels.BaseEntityModels;
using Models.UtilModels;

namespace DataManager.BaseRepositories
{
    public abstract class BaseRepository<TEntity> : BaseRepository<TEntity, Guid, AnywayBankDbContext>
        where TEntity : class, IEntity<Guid>, new()
    {
        protected BaseRepository(AnywayBankDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }

    public abstract class BaseRepository<TEntity, TKey, TDbContext> : BaseUnitOfWork<TDbContext>,
        IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
        where TKey : struct, IEquatable<TKey>
        where TDbContext : DbContext
    {
        protected readonly IMapper Mapper;
        protected readonly DbSet<TEntity> RepoDbSet;

        protected BaseRepository(TDbContext context, IMapper mapper)
            : base(context)
        {
            Mapper = mapper;
            RepoDbSet = Context.Set<TEntity>();
        }

        public virtual ResultModel<TModel> Create<TModel>(TModel model, bool autoCommit = false)
            where TModel : class, IEntityModel<TKey>, new()
        {
            var alreadyCreated = Any<TModel>(_ => _.Id.Equals(model.Id));
            if (alreadyCreated) return ResultModel<TModel>.BadResult(1001, "Entity already exists.");

            var entity = Mapper.Map<TEntity>(model);
            entity = RepoDbSet.Add(entity).Entity;
            Mapper.Map(entity, model);

            if (autoCommit) Commit();
            return ResultModel<TModel>.Ok(model);
        }

        public virtual ResultModel<TModel> Update<TModel>(TModel model, bool autoCommit = false)
            where TModel : class, IEntityModel<TKey>, new()
        {
            var entity = GetInternal<TModel>(_ => _.Id.Equals(model.Id));
            if (!entity.Success) return ResultModel<TModel>.Copy(entity);

            Mapper.Map(model, entity.Data);
            entity.Data = RepoDbSet.Update(entity.Data).Entity;
            Mapper.Map(entity.Data, model);

            if (autoCommit) Commit();
            return ResultModel<TModel>.Ok(model);
        }

        public virtual ResultModel<object> Remove<TModel>(TModel model, bool autoCommit = false)
            where TModel : class, IEntityModel<TKey>, new()
        {
            var entity = GetInternal<TModel>(_ => _.Id.Equals(model.Id));
            if (!entity.Success) return ResultModel<object>.Copy(entity);

            RepoDbSet.Remove(entity.Data);

            if (autoCommit) Commit();
            return ResultModel<object>.Ok(null);
        }

        public virtual IEnumerable<TModel> GetAll<TModel>(Expression<Func<TModel, bool>> predicate,
            bool asNoTracking = true)
            where TModel : class, IEntityModel<TKey>, new() =>
            asNoTracking
                ? QuerySet(predicate)
                    .AsNoTracking()
                    .ProjectTo<TModel>(Mapper.ConfigurationProvider)
                    .ToList()
                : QuerySet(predicate)
                    .ProjectTo<TModel>(Mapper.ConfigurationProvider)
                    .ToList();

        public virtual ResultModel<TModel> Get<TModel>(Expression<Func<TModel, bool>> predicate,
            bool asNoTracking = true)
            where TModel : class, IEntityModel<TKey>, new()
        {
            var entity = GetInternal(predicate);
            return ResultModel<TModel>.Copy(entity);
        }

        public virtual bool Any<TModel>(Expression<Func<TModel, bool>> predicate)
            where TModel : class, IEntityModel<TKey>, new() =>
            RepoDbSet.Any(MapPredicate(predicate));

        public virtual async Task<IEnumerable<TModel>> GetAllAsync<TModel>(Expression<Func<TModel, bool>> predicate,
            bool asNoTracking = true)
            where TModel : class, IEntityModel<TKey>, new() =>
            asNoTracking
                ? await QuerySet(predicate)
                    .AsNoTracking()
                    .ProjectTo<TModel>(Mapper.ConfigurationProvider)
                    .ToListAsync()
                : await QuerySet(predicate)
                    .ProjectTo<TModel>(Mapper.ConfigurationProvider)
                    .ToListAsync();

        public virtual async Task<ResultModel<TModel>> GetAsync<TModel>(Expression<Func<TModel, bool>> predicate,
            bool asNoTracking = true)
            where TModel : class, IEntityModel<TKey>, new()
        {
            var entity = await GetInternalAsync(predicate);
            return ResultModel<TModel>.Copy(entity);
        }

        public virtual async Task<bool> AnyAsync<TModel>(Expression<Func<TModel, bool>> predicate)
            where TModel : class, IEntityModel<TKey>, new() =>
            await RepoDbSet.AnyAsync(MapPredicate(predicate));

        protected virtual ResultModel<TEntity> GetInternal<TModel>(Expression<Func<TModel, bool>> predicate,
            bool asNoTracking = true)
            where TModel : class, IEntityModel<TKey>, new()
        {
            var entity = asNoTracking
                ? RepoDbSet.AsNoTracking().FirstOrDefault(MapPredicate(predicate))
                : RepoDbSet.FirstOrDefault(MapPredicate(predicate));

            return entity != null
                ? ResultModel<TEntity>.Ok(entity)
                : ResultModel<TEntity>.BadResult(1001, "Entity not found.");
        }

        protected virtual async Task<ResultModel<TEntity>> GetInternalAsync<TModel>(
            Expression<Func<TModel, bool>> predicate, bool asNoTracking = true)
            where TModel : class, IEntityModel<TKey>, new()
        {
            var entity = asNoTracking
                ? await RepoDbSet.AsNoTracking().FirstOrDefaultAsync(MapPredicate(predicate))
                : await RepoDbSet.FirstOrDefaultAsync(MapPredicate(predicate));

            return entity != null
                ? ResultModel<TEntity>.Ok(entity)
                : ResultModel<TEntity>.BadResult(1001, "Entity not found.");
        }

        private IQueryable<TEntity> QuerySet<TModel>(Expression<Func<TModel, bool>> predicate = null)
            where TModel : class, IEntityModel<TKey>, new() =>
            predicate != null
                ? RepoDbSet.Where(MapPredicate(predicate))
                : RepoDbSet;

        private Expression<Func<TEntity, bool>> MapPredicate<TModel>(Expression<Func<TModel, bool>> predicate)
            where TModel : class, IEntityModel<TKey>, new() =>
            Mapper.Map<Expression<Func<TEntity, bool>>>(predicate);
    }
}