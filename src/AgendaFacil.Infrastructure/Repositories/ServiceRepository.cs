using AgendaFacil.Application.Interface.Repositories;
using AgendaFacil.Domain.Entities;
using AgendaFacil.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AgendaFacil.Infrastructure.Repositories;

public class ServiceRepository : BaseRepository<Service>, IServiceRepository
{
    private readonly AgendaFacilDbContext _context;
    public ServiceRepository(AgendaFacilDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Service>?> GetAllServices(CancellationToken cancellationToken)
    {
        var service = await _context.Services
            .ToListAsync(cancellationToken);

        if (service is null)
        {
            return null;
        }

        return service;
    }
    public async Task<Service?> GetServiceById(Guid serviceId, CancellationToken cancellationToken)
    {
        var service = await _context.Services
            .Where(x => x.Id == serviceId)
            .FirstOrDefaultAsync(cancellationToken);

        if (service is null)
        {
            return null;
        }

        return service;
    }
}
