using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gproject.Api.Controllers
{
    // this Class not important with handling middelware not important now
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            var (statusCode, message) = exception switch
            {
                _ => (StatusCodes.Status500InternalServerError, "An inexpexted error occurred. ")
            };

            return Problem(statusCode: statusCode, title: message);
        }
    }
}
