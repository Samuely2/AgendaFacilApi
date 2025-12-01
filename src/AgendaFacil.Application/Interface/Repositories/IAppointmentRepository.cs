using AgendaFacil.Domain.Entities;
using AgendaFacil.Domain.Interface;
namespace AgendaFacil.Application.Interface.Repositories;

public interface IAppointmentRepository : IBaseRepository<Appointment>
{
    Task<List<Appointment>?> GetAppointmentsByUserIdAsync(Guid? userId, string? role, CancellationToken cancellationToken);
    Task<Appointment?> GetAppointmentByid(Guid id, CancellationToken cancellationToken);
}
