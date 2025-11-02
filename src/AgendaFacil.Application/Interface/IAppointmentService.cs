using AgendaFacil.Application.DTOs.Request;
using AgendaFacil.Application.DTOs.Response;
using AgendaFacil.Domain.Entities;

namespace AgendaFacil.Application.Interface;

public interface IAppointmentService
{
    Task<Appointment?> CreateAppointment(AppointmentRequestDTO dto, CancellationToken cancellationToken);
    Task<List<AppointmentResponseDTO>?> GetAppointmentsByUserIdAsync(CancellationToken cancellationToken);
}
