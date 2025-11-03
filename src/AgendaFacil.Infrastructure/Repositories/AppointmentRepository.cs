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

    public async Task<List<Appointment>?> GetAppointmentsByUserIdAsync(Guid? userId, string? role, CancellationToken cancellationToken)
    {
        if (userId == null) return null;

        var entity = await GetAppointmentsByRoleId(userId, role, cancellationToken);

        return entity;
    }

    private async Task<List<Appointment>?> GetAppointmentsByRoleId(Guid? userId, string? role, CancellationToken cancellationToken)
    {
        if (role == "Client")
        {
            var entity = await _context.Appointments
            .Where(x => x.UserId == userId)
            .ToListAsync(cancellationToken);

            return entity;
        }

        if (role == "ServiceProvider")
        {
            var entity = await _context.Appointments
            .Include(s => s.ServiceProvider)
            .Where(s => s.ServiceProvider!.UserId != null && s.ServiceProvider.UserId == userId)
            .ToListAsync(cancellationToken);

            return entity;
        }

        return null;
    }
}
