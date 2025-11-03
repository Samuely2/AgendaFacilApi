using AgendaFacil.Application.DTOs.Request;
using AgendaFacil.Application.DTOs.Response;
using AgendaFacil.Domain.Entities;

namespace AgendaFacil.Application.Interfaces;

public interface IServiceProviderService
{
    Task<ServiceProviderResponseDTO?> CreateServiceProvider(ServiceProviderRequestDTO dto, CancellationToken cancellationToken);
    Task<List<ServiceProviderResponseDTO>?> GetAllServiceProviders(CancellationToken cancellationToken);
    Task<ServiceProviderResponseDTO?> GetServiceProviderById(Guid id, CancellationToken cancellationToken);
}
