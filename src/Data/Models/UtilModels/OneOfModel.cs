using Data.Models.InternalModels.BaseEntityModels;
using Data.Models.UtilModels.ErrorModels;
using OneOf;

namespace Data.Models.UtilModels
{
    public class OneOfModel<TEntityModel, TError> : OneOfBase<TEntityModel, TError> 
        where TError : BaseErrorModel
    {
        protected OneOfModel(OneOf<TEntityModel, TError> input) 
            : base(input)
        {
        }

        public static implicit operator OneOfModel<TEntityModel, TError>(TEntityModel _) => new(_);
        public static implicit operator OneOfModel<TEntityModel, TError>(TError _) => new(_);
    }
}