using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using Gproject.Application.Authentication.Commands.Register;
using Gproject.Application.Authentication.Common;
using Gproject.Domain.Common.Errors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Application.Common.Behaviors
{
    public class ValidateBehavior<TRequest, TResponse> :IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
    {    
        private readonly IValidator<TRequest>? _validator;

        public ValidateBehavior(IValidator<TRequest>? validator = null)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (_validator is null)
            {
                return await next();
            }
            var ValidationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (ValidationResult.IsValid)
            {
                return await next();
            }
            var errors = ValidationResult.Errors.ConvertAll(ValidationFailure => 
                            Error.Validation(ValidationFailure.PropertyName, ValidationFailure.ErrorMessage));
            return (dynamic)errors;
        }
    }
}
