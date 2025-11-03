using AgendaFacil.Application.DTOs.Request;
using AgendaFacil.Application.DTOs.Response;
using AgendaFacil.Domain.Entities;

namespace AgendaFacil.Application.Interface;

public interface IServiceService
{
    Task<Service?> CreateServiceAsync(ServiceRequestDTO dto, CancellationToken cancellationToken);
    Task<List<ServiceResponseDTO>?> GetAllServices(CancellationToken cancellationToken);
    Task<bool> DeleteServiceById(Guid serviceId, CancellationToken cancellationToken);
    Task<ServiceResponseDTO?> GetServiceById(Guid serviceId, CancellationToken cancellationToken);
    Task<Service?> UpdateServiceById(Guid serviceId, ServiceRequestDTO dto, CancellationToken cancellationToken);
}
