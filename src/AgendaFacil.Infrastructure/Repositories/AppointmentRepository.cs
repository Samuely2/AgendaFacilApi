using AgendaFacil.Application.Interface.Repositories;
using AgendaFacil.Domain.Entities;
using AgendaFacil.Domain.Repositories;

namespace AgendaFacil.Infrastructure.Repositories;

public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
{
    private readonly AgendaFacilDbContext _context;
    public AppointmentRepository(AgendaFacilDbContext context) : base(context)
    {
        _context = context;
    }


}
