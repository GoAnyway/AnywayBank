using CommonData.BaseRequests;
using CommonData.UtilModels.ErrorModels;
using Core.BaseHandlers;

namespace AnywayBankCore.BaseHandlers
{
    public interface IAnywayBankRequestHandler<in TRequest, TModel> : IOneOfRequestHandler<TRequest, TModel, DefaultErrorModel>
        where TRequest : IOneOfRequest<TModel, DefaultErrorModel>
    {
    }
}