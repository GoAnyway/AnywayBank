using System;
using Database.BaseEntities;
using Models.InternalModels.BaseEntityModels;
using Models.UtilModels;

namespace DataManager.BaseRepositories
{
    public interface IRepositoryCommon<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
        where TKey : struct, IEquatable<TKey>
    {
        ResultModel<TModel> Create<TModel>(TModel model, bool autoCommit = false) 
            where TModel : class, IEntityModel<TKey>, new();
        ResultModel<TModel> Update<TModel>(TModel model, bool autoCommit = false) 
            where TModel : class, IEntityModel<TKey>, new();
        ResultModel<object> Remove<TModel>(TModel model, bool autoCommit = false) 
            where TModel : class, IEntityModel<TKey>, new();
    }
}