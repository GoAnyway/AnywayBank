using CommonData.UtilModels.ErrorModels;
using OneOf;

namespace CommonData.UtilModels
{
    public class OneOfModel<TModel, TError> : OneOfBase<TModel, TError>
        where TError : BaseErrorModel
    {
        protected OneOfModel(OneOf<TModel, TError> input)
            : base(input)
        {
        }

        public static implicit operator OneOfModel<TModel, TError>(TModel _) => new(_);
        public static implicit operator OneOfModel<TModel, TError>(TError _) => new(_);
    }
}