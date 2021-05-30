using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CommonData.BaseEntityModels;
using CommonData.UtilModels;
using CommonData.UtilModels.ErrorModels;
using CommonDatabase.BaseEntities;

namespace CommonDataManager.BaseRepositories
{
    public interface IRepositoryAsync<TEntity, TError>
        where TEntity : BaseEntity
        where TError : BaseErrorModel
    {
        Task<IEnumerable<TModel>> GetAllAsync<TModel>(Expression<Func<TModel, bool>> predicate)
            where TModel : BaseEntityModel, new();

        Task<OneOfModel<TModel, TError>> GetAsync<TModel>(Expression<Func<TModel, bool>> predicate)
            where TModel : BaseEntityModel, new();

        Task<bool> AnyAsync<TModel>(Expression<Func<TModel, bool>> predicate)
            where TModel : BaseEntityModel, new();
    }
}