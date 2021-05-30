using CommonData.BaseRequests;
using CommonData.UtilModels.ErrorModels;
using Core.BaseBehaviors.Validation;

namespace IdentityCore.Behaviors
{
    public interface IIdentityValidationPipelineBehavior<in TRequest, TModel> : IOneOfValidationBehavior<TRequest, TModel, DefaultErrorModel>
        where TRequest : IOneOfRequest<TModel, DefaultErrorModel>
    {
    }
}