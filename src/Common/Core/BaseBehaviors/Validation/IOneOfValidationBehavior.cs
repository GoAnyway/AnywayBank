using CommonData.BaseRequests;
using CommonData.UtilModels;
using CommonData.UtilModels.ErrorModels;
using MediatR;

namespace Core.BaseBehaviors.Validation
{
    public interface
        IOneOfValidationBehavior<in TRequest, TModel, TError> : IPipelineBehavior<TRequest, OneOfModel<TModel, TError>>
        where TRequest : IOneOfRequest<TModel, TError>
        where TError : BaseErrorModel
    {
    }
}