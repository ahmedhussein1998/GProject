using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Gproject.Api.Filter
{
    public class ErrorHandlingFilterAttribute :ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var problemDetails = new ProblemDetails
            { 
                Title = "An Error occurred while processing your request",
                Status = (int)HttpStatusCode.InternalServerError,
                Detail = exception.Message
            };


            context.Result = new ObjectResult( problemDetails );
            context.ExceptionHandled = true;
        }
    }
}
