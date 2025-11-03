using AgendaFacil.Application.Interface.Repositories;
using AgendaFacil.Domain.Entities;
using AgendaFacil.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AgendaFacil.Infrastructure.Repositories;

public class ServiceProviderRepository : BaseRepository<ServiceProviderProfile>, IServiceProviderRepository
{
    private readonly AgendaFacilDbContext _context;
    public ServiceProviderRepository(AgendaFacilDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ServiceProviderProfile?> GetServiceProfileById(Guid id, CancellationToken cancellationToken)
    {

        var entity = await _context.ServiceProviderProfiles
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is null) return null;

        return entity;
    }

    public async Task<ServiceProviderProfile?> GetServiceProviderByUserIdAsync(Guid? userid, CancellationToken cancellationToken)
    {
        var entity = await _context.ServiceProviderProfiles
            .Where(x => x.UserId == userid)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is null) return null;

        return entity;
    }

    public async Task<List<ServiceProviderProfile>?> GetAll(CancellationToken cancellationToken)
    {
        var entity = await _context.ServiceProviderProfiles
            .ToListAsync(cancellationToken);

        if (entity is null) return null;

        return entity;
    }
}
