using AgendaFacil.Application.Interfaces;
using System.Diagnostics;
using System.Security.Claims;

namespace AgendaFacil.Api.Middleware;

public sealed class ApplicationUserContext(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context, IUserContextService userContextService)
    {
        string? userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
        string? role = context.User?.FindFirstValue(ClaimTypes.Role);

        if (userId is not null)
        {
            userContextService.UserId = Guid.Parse(userId);
            userContextService.Role = role;
        }
        
        await next(context);        
    }
}