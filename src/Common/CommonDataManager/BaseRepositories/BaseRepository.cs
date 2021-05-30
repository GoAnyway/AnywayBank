using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CommonData.BaseEntityModels;
using CommonData.UtilModels;
using CommonData.UtilModels.ErrorModels;
using CommonDatabase.BaseEntities;
using CommonDataManager.BaseUnitsOfWork;
using Microsoft.EntityFrameworkCore;

namespace CommonDataManager.BaseRepositories
{
    public abstract class BaseRepository<TEntity, TDbContext, TError> : BaseUnitOfWork<TDbContext>,
        IRepository<TEntity, TError>
        where TEntity : BaseEntity
        where TDbContext : DbContext
        where TError : BaseErrorModel, new()
    {
        protected readonly IMapper Mapper;
        protected readonly DbSet<TEntity> RepoDbSet;

        protected BaseRepository(TDbContext context, IMapper mapper)
            : base(context)
        {
            Mapper = mapper;
            RepoDbSet = Context.Set<TEntity>();
        }

        public virtual OneOfModel<TModel, TError> Create<TModel>(TModel model, bool autoCommit = false)
            where TModel : BaseEntityModel, new()
        {
            var alreadyCreated = Any<TModel>(_ => _.Id.Equals(model.Id));
            if (alreadyCreated) return BaseErrorModel.Create<TError>(1001, "Entity already exists.");

            var entity = Mapper.Map<TEntity>(model);
            entity = RepoDbSet.Add(entity).Entity;
            Mapper.Map(entity, model);

            if (autoCommit) Context.SaveChanges();
            return model;
        }

        public virtual OneOfModel<TModel, TError> Update<TModel>(TModel model, bool autoCommit = false)
            where TModel : BaseEntityModel, new()
        {
            var getEntityResult = GetInternal<TModel>(_ => _.Id.Equals(model.Id));
            if (getEntityResult.IsT1) return getEntityResult.AsT1;

            Mapper.Map(model, getEntityResult.AsT0);

            if (autoCommit) Context.SaveChanges();
            return model;
        }

        public virtual OneOfModel<object, TError> Remove<TModel>(TModel model, bool autoCommit = false)
            where TModel : BaseEntityModel, new()
        {
            var getEntityResult = GetInternal<TModel>(_ => _.Id.Equals(model.Id));
            if (getEntityResult.IsT1) return getEntityResult.AsT1;

            RepoDbSet.Remove(getEntityResult.AsT0);

            if (autoCommit) Context.SaveChanges();
            return 0;
        }

        public virtual IEnumerable<TModel> GetAll<TModel>(Expression<Func<TModel, bool>> predicate)
            where TModel : BaseEntityModel, new() =>
            QuerySet(predicate)
                .ProjectTo<TModel>(Mapper.ConfigurationProvider)
                .ToList();

        public virtual OneOfModel<TModel, TError> Get<TModel>(Expression<Func<TModel, bool>> predicate)
            where TModel : BaseEntityModel, new()
        {
            var getEntityResult = GetInternal(predicate);
            return getEntityResult.IsT0
                ? Mapper.Map<TModel>(getEntityResult.AsT0)
                : getEntityResult.AsT1;
        }

        public virtual bool Any<TModel>(Expression<Func<TModel, bool>> predicate)
            where TModel : BaseEntityModel, new() =>
            RepoDbSet.Any(MapPredicate(predicate));

        public virtual async Task<IEnumerable<TModel>> GetAllAsync<TModel>(Expression<Func<TModel, bool>> predicate)
            where TModel : BaseEntityModel, new() =>
            await QuerySet(predicate)
                .ProjectTo<TModel>(Mapper.ConfigurationProvider)
                .ToListAsync();

        public virtual async Task<OneOfModel<TModel, TError>> GetAsync<TModel>(Expression<Func<TModel, bool>> predicate)
            where TModel : BaseEntityModel, new()
        {
            var getEntityResult = await GetInternalAsync(predicate);
            return getEntityResult.IsT0
                ? Mapper.Map<TModel>(getEntityResult.AsT0)
                : getEntityResult.AsT1;
        }

        public virtual async Task<bool> AnyAsync<TModel>(Expression<Func<TModel, bool>> predicate)
            where TModel : BaseEntityModel, new() =>
            await RepoDbSet.AnyAsync(MapPredicate(predicate));

        protected virtual OneOfModel<TEntity, TError> GetInternal<TModel>(Expression<Func<TModel, bool>> predicate)
            where TModel : BaseEntityModel, new()
        {
            var entity = RepoDbSet.FirstOrDefault(MapPredicate(predicate));

            return entity != null
                ? entity
                : BaseErrorModel.Create<TError>(1001, "Entity not found.");
        }

        protected virtual async Task<OneOfModel<TEntity, TError>> GetInternalAsync<TModel>(
            Expression<Func<TModel, bool>> predicate)
            where TModel : BaseEntityModel, new()
        {
            var entity = await RepoDbSet.FirstOrDefaultAsync(MapPredicate(predicate));

            return entity != null
                ? entity
                : BaseErrorModel.Create<TError>(1001, "Entity not found.");
        }

        private IQueryable<TEntity> QuerySet<TModel>(Expression<Func<TModel, bool>> predicate = null)
            where TModel : BaseEntityModel, new() =>
            predicate != null
                ? RepoDbSet.Where(MapPredicate(predicate))
                : RepoDbSet;

        private Expression<Func<TEntity, bool>> MapPredicate<TModel>(Expression<Func<TModel, bool>> predicate)
            where TModel : BaseEntityModel, new() =>
            Mapper.Map<Expression<Func<TEntity, bool>>>(predicate);
    }
}