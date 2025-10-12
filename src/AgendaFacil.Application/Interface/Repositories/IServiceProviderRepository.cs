using AgendaFacil.Domain.Entities;
using AgendaFacil.Domain.Interface;

namespace AgendaFacil.Application.Interface.Repositories;

public interface IServiceProviderRepository : IBaseRepository<ServiceProviderProfile>
{
    Task<List<string?>?> GetSpecialityByUserId(Guid? userId, CancellationToken cancellationToken);
}
