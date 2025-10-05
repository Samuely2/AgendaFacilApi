namespace AgendaFacil.Application.Interfaces;

public interface IServiceProviderService
{
    Task<string?> CreateServiceProvider(string? speciality, CancellationToken cancellationToken);
}
