using CommonData.UtilModels;
using CommonData.UtilModels.ErrorModels;
using MediatR;

namespace CommonData.BaseRequests
{
    public interface IOneOfRequest<TModel, TError> : IRequest<OneOfModel<TModel, TError>>
        where TError : BaseErrorModel
    {
    }
}