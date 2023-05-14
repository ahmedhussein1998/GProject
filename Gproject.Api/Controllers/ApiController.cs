using ErrorOr;
using Gproject.Api.Common.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace Gproject.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class ApiController : ControllerBase
    {
        private IHttpContextAccessor _httpContextAccessor;
        public ApiController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string ServerRootPath { get { return $"{Request.Scheme}://{Request.Host}{Request.PathBase}"; } }
        public string IP { get { return _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.MapToIPv4().ToString(); } }
        protected IActionResult Problem(List<Error> errors)
        {
            if (errors.Count is 0)
            {
                return Problem();
            }
            if(errors.All(error => error.Type == ErrorType.Validation)) 
            {
                return ValidationProblem(errors);
            }
            HttpContext.Items[HttpContextitemKeys.Errors] = errors;

            return Problem(errors[0]);
        }

        private IActionResult ValidationProblem(List<Error> errors)
        {
            var modelStateDictionary = new ModelStateDictionary();
            foreach (var error in errors)
            {
                modelStateDictionary.AddModelError(error.Code, error.Description);
            }
            return ValidationProblem(modelStateDictionary);
        }

        private IActionResult Problem(Error error)
        {
            var statusCode = error.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };
            return Problem(statusCode: statusCode, title: error.Description);
        }
    }
}
