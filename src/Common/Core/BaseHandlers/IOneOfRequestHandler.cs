using CommonData.BaseRequests;
using CommonData.UtilModels;
using CommonData.UtilModels.ErrorModels;
using MediatR;

namespace Core.BaseHandlers
{
    public interface
        IOneOfRequestHandler<in TRequest, TModel, TError> : IRequestHandler<TRequest, OneOfModel<TModel, TError>>
        where TRequest : IOneOfRequest<TModel, TError>
        where TError : BaseErrorModel
    {
    }
}