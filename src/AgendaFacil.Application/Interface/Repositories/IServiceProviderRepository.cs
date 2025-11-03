using AgendaFacil.Domain.Entities;
using AgendaFacil.Domain.Interface;

namespace AgendaFacil.Application.Interface.Repositories;

public interface IServiceProviderRepository : IBaseRepository<ServiceProviderProfile>
{
    Task<List<ServiceProviderProfile>?> GetAll(CancellationToken cancellationToken);
    Task<ServiceProviderProfile?> GetServiceProviderByUserIdAsync(Guid? userid, CancellationToken cancellationToken);
    Task<ServiceProviderProfile?> GetServiceProfileById(Guid id, CancellationToken cancellationToken);
}
