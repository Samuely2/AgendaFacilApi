using AgendaFacil.Application.Interface.Repositories;
using AgendaFacil.Domain.Entities;
using AgendaFacil.Domain.Repositories;

namespace AgendaFacil.Infrastructure.Repositories;

public class AvailabilityRepository : BaseRepository<Availability>, IAvailabilityRepository
{
    private readonly AgendaFacilDbContext _context;
    public AvailabilityRepository(AgendaFacilDbContext context) : base(context)
    {
        _context = context;
    }

}
