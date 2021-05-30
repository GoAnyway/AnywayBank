using CommonData.BaseRequests;
using CommonData.UtilModels.ErrorModels;

namespace Data.BaseRequests
{
    public interface IAnywayBankRequest<TModel> : IOneOfRequest<TModel, DefaultErrorModel>
    {

    }
}