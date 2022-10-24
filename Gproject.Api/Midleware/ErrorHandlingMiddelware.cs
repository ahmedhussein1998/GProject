using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gproject.Api.Midleware
{
    public class ErrorHandlingMiddelware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddelware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                await HandleExcptionAsync(context, ex);
            }
        }
        private static Task HandleExcptionAsync(HttpContext context,Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(new { error = "An Error Occurred While Processing Your Request" });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
