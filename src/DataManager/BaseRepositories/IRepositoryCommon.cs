using System;
using Database.BaseEntities;
using Models.InternalModels.BaseEntityModels;
using Models.UtilModels;

namespace DataManager.BaseRepositories
{
    public interface IRepositoryCommon<TEntity, TModel, TKey>
        where TEntity : class, IEntity<TKey>, new()
        where TModel : IEntityModel<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        ResultModel<TModel> Create(TModel model);
        ResultModel<TModel> Update(TModel model);
        ResultModel<object> Remove(TModel model);
    }
}