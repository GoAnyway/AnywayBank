using System.Collections.Generic;
using CommonData.BaseRequests;
using CommonData.UtilModels.ErrorModels;
using Core.BaseBehaviors.Validation;
using FluentValidation;

namespace IdentityCore.Behaviors
{
    public class IdentityValidationPipelineBehavior<TRequest, TModel> : BaseValidationBehavior<TRequest, TModel, DefaultErrorModel>,
        IIdentityValidationPipelineBehavior<TRequest, TModel>
        where TRequest : IOneOfRequest<TModel, DefaultErrorModel>
    {
        public IdentityValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
            : base(validators)
        {
        }
    }
}