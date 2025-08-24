using AgendaFacil.Domain.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace AgendaFacil.CrossCutting.IoC;

public static class ApplicationConfiguration
{
    public static void ApplicationConfigure(this IServiceCollection services)
    {
        services.AddScoped<NotificationContext>();
    }

}
