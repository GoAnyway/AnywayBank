using System;
using Database.BaseEntities;
using Models.InternalModels.BaseEntityModels;

namespace DataManager.BaseRepositories
{
    public interface IRepository<TEntity, TModel> : IRepository<TEntity, TModel, Guid>
        where TEntity : class, IEntity<Guid>, new() 
        where TModel : IEntityModel<Guid>
    {
    }

    public interface IRepository<TEntity, TModel, TKey> : IRepositoryCommon<TEntity, TModel, TKey>,
        IRepositorySync<TEntity, TModel, TKey>, IRepositoryAsync<TEntity, TModel, TKey>
        where TEntity : class, IEntity<TKey>, new()
        where TModel : IEntityModel<TKey>
        where TKey : struct, IEquatable<TKey>
    {
    }
}