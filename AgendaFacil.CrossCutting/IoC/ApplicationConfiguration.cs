using AgendaFacil.Application.Interface.Repositories;
using AgendaFacil.Application.Interfaces;
using AgendaFacil.Application.Services;
using AgendaFacil.Domain.Notifications;
using AgendaFacil.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AgendaFacil.CrossCutting.IoC;

public static class ApplicationConfiguration
{
    public static void ApplicationConfigure(this IServiceCollection services)
    {
        services.AddScoped<NotificationContext>();
        services.AddScoped<IUserContextService, UserContextService>();
        services.AddScoped<IServiceProviderService, ServiceProviderService>();
        services.AddScoped<IServiceProviderRepository, ServiceProviderRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

    }

}
