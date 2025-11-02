using AgendaFacil.Application.Interface.Repositories;
using AgendaFacil.Domain.Entities;
using AgendaFacil.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AgendaFacil.Infrastructure.Repositories;

public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
{
    private readonly AgendaFacilDbContext _context;
    public AppointmentRepository(AgendaFacilDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Appointment>?> GetAppointmentsByUserIdAsync(Guid? userId, CancellationToken cancellationToken)
    {
        if (userId == null) return null;

        var entity = await _context.Appointments
            .Where(x => x.UserId == userId)
            .ToListAsync(cancellationToken);

        return entity;
    }
}
