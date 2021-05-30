using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CommonData.BaseEntityModels;
using CommonData.UtilModels;
using CommonData.UtilModels.ErrorModels;
using CommonDatabase.BaseEntities;

namespace CommonDataManager.BaseRepositories
{
    public interface IRepositorySync<TEntity, TError>
        where TEntity : BaseEntity
        where TError : BaseErrorModel
    {
        IEnumerable<TModel> GetAll<TModel>(Expression<Func<TModel, bool>> predicate)
            where TModel : BaseEntityModel, new();

        OneOfModel<TModel, TError> Get<TModel>(Expression<Func<TModel, bool>> predicate)
            where TModel : BaseEntityModel, new();

        bool Any<TModel>(Expression<Func<TModel, bool>> predicate)
            where TModel : BaseEntityModel, new();
    }
}