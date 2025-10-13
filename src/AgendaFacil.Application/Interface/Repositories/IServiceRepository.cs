using AgendaFacil.Domain.Entities;
using AgendaFacil.Domain.Interface;

namespace AgendaFacil.Application.Interface.Repositories;

public interface IServiceRepository : IBaseRepository<Service>
{
    Task<List<Service>?> GetAllServices(CancellationToken cancellationToken);
    Task<Service?> GetServiceById(Guid serviceId, CancellationToken cancellationToken);
}
