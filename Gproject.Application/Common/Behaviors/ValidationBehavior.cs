using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Gproject.Application.Common.Behaviors
{
    public class ValidateBehavior<TRequest, TResponse> :IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
    {    
        private readonly IValidator<TRequest>? _validator;
        private readonly ILogger<ValidateBehavior<TRequest, TResponse>> _logger;

        public ValidateBehavior(ILogger<ValidateBehavior<TRequest, TResponse>> logger, IValidator<TRequest>? validator = null)
        {
            _validator = validator;
            _logger = logger;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {

             LogRequest("Starting");

            if (_validator is null)
            {
               var result = await next();
                if(result.IsError)
                {

                    LogErrorRequest("Error occurred during", string.Join("; ", result?.Errors?.Select(e => e.Description ?? "") ?? new List<string>()));
                }
               LogRequest("Completed");
                return result;
                 

            }
            var ValidationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (ValidationResult.IsValid)
            {
                var result = await next();
                if (result.IsError)
                {
                    LogErrorRequest("Error occurred during", string.Join("; ", result?.Errors?.Select(e => e.Description ?? "") ?? new List<string>()));
                }
                LogRequest("Completed");
                return result;

            }
            var errors = ValidationResult.Errors.ConvertAll(ValidationFailure => 
                            Error.Validation(ValidationFailure.PropertyName, ValidationFailure.ErrorMessage));
                   LogErrorRequest("Error occurred during", string.Join("; ", errors?.Select(e => e.Description ?? "") ?? new List<string>()));

            return (dynamic)errors;
        }

        private void LogRequest(string status)
        {
            _logger.LogInformation(
                "{@Status} request {@RequestName}, {@DateTimeUtc}",
                status,
                typeof(TRequest).Name,
                DateTime.UtcNow);
        }


        private void LogErrorRequest(string status, string errors)
        {
            _logger.LogError(
                "{@Status} request {@RequestName},With Errors {@Error} , At {@DateTimeUtc}",
                status,
                typeof(TRequest).Name,
                errors,
                DateTime.UtcNow);
        }

    }
}
