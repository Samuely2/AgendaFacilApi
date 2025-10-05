using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace AgendaFacil.Api.Exceptions
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            var exceptionResponse = new ExceptionResponse()
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Title = "Unexpected Error Occured",
                ExceptionMessage = exception.Message,
                ExceptionDateTime = DateTime.UtcNow,
                StackTrace = exception.StackTrace ?? "No Stack Trace Found"
            };

            var jsonResponse = JsonSerializer.Serialize(exceptionResponse);

            httpContext.Response.StatusCode = exceptionResponse.StatusCode;
            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsync(jsonResponse);

            return true;
        }
    }
}
