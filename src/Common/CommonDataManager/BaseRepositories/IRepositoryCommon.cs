using CommonData.BaseEntityModels;
using CommonData.UtilModels;
using CommonData.UtilModels.ErrorModels;
using CommonDatabase.BaseEntities;

namespace CommonDataManager.BaseRepositories
{
    public interface IRepositoryCommon<TEntity, TError>
        where TEntity : BaseEntity
        where TError : BaseErrorModel
    {
        OneOfModel<TModel, TError> Create<TModel>(TModel model, bool autoCommit = false)
            where TModel : BaseEntityModel, new();

        OneOfModel<TModel, TError> Update<TModel>(TModel model, bool autoCommit = false)
            where TModel : BaseEntityModel, new();

        OneOfModel<object, TError> Remove<TModel>(TModel model, bool autoCommit = false)
            where TModel : BaseEntityModel, new();
    }
}