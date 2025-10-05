namespace AgendaFacil.Api.Middleware;

public class GlobalMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalMiddleware> _logger;
    public GlobalMiddleware(RequestDelegate next, ILogger<GlobalMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path}");
        await _next(context);
        _logger.LogInformation($"Response: {context.Response.StatusCode}");
    }

}
