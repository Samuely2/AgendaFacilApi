using AgendaFacil.Application.Interface.Repositories;
using AgendaFacil.Domain.Entities;
using AgendaFacil.Domain.Repositories;

namespace AgendaFacil.Infrastructure.Repositories;

public class ServiceRepository : BaseRepository<Service>, IServiceRepository
{
    private readonly AgendaFacilDbContext _context;
    public ServiceRepository(AgendaFacilDbContext context) : base(context)
    {
        _context = context;
    }

}
