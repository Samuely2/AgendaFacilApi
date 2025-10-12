using AgendaFacil.Application.DTOs.Request;
using AgendaFacil.Domain.Entities;

namespace AgendaFacil.Application.Interface;

public interface IServiceService
{
    Task<Service?> CreateServiceAsync(ServiceRequestDTO dto, CancellationToken cancellationToken);
}
