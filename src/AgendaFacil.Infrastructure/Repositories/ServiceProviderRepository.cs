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

    public async Task<List<string?>?> GetSpecialityByUserId(Guid? userId, CancellationToken cancellationToken)
    {
        var speciality = await _context.ServiceProviderProfiles
            .Where(x => x.UserId == userId)
            .Select(x => x.Speciality)
            .ToListAsync(cancellationToken);
            
        if (speciality is null)
        {
            return null;
        }

        return speciality;
    }

    public async Task <List<ServiceProviderProfile>?> GetServiceProviderByUserIdAsync (Guid? userid, CancellationToken cancellationToken)
    {
        var entity = await _context.ServiceProviderProfiles
            .Where(x => x.UserId == userid)
            .ToListAsync(cancellationToken);

        if (entity is null) return null;

        return entity;
    }
}
