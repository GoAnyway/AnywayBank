using CommonData.BaseRequests;
using CommonData.UtilModels.ErrorModels;

namespace Data.BaseRequests
{
    public interface IIdentityRequest<TModel> : IOneOfRequest<TModel, DefaultErrorModel>
    {
    }
}