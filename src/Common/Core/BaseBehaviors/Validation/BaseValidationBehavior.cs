using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CommonData.BaseRequests;
using CommonData.UtilModels;
using CommonData.UtilModels.ErrorModels;
using FluentValidation;
using MediatR;

namespace Core.BaseBehaviors.Validation
{
    public abstract class BaseValidationBehavior<TRequest, TModel, TError> : IOneOfValidationBehavior<TRequest, TModel, TError>
        where TRequest : IOneOfRequest<TModel, TError>
        where TError : BaseErrorModel, new()
    {
        protected readonly IEnumerable<IValidator<TRequest>> Validators;

        protected BaseValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            Validators = validators.ToList();
        }

        public async Task<OneOfModel<TModel, TError>> Handle(TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<OneOfModel<TModel, TError>> next)
        {
            if (!Validators.Any()) return await next.Invoke();

            var context = new ValidationContext<TRequest>(request);
            var validationResults =
                await Task.WhenAll(Validators.Select(_ => _.ValidateAsync(context, cancellationToken)));
            var failures = validationResults
                .SelectMany(_ => _.Errors)
                .Where(_ => _ != null)
                .ToList();

            return failures.Any()
                ? BaseErrorModel.Create<TError>(3003, failures.Select(_ => _.ErrorMessage))
                : await next.Invoke();
        }
    }
}