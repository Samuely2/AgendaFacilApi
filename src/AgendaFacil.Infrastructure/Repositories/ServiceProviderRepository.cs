using AgendaFacil.Application.Interface.Repositories;
using AgendaFacil.Domain.Entities;
using AgendaFacil.Domain.Repositories;

namespace AgendaFacil.Infrastructure.Repositories;

public class ServiceProviderRepository : BaseRepository<ServiceProviderProfile>, IServiceProviderRepository
{
    private readonly AgendaFacilDbContext _context;
    public ServiceProviderRepository(AgendaFacilDbContext context) : base(context)
    {
        _context = context;
    }
}
