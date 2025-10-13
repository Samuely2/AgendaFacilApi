namespace AgendaFacil.Application.DTOs.Request;

public record AppointmentRequestDTO
(
    Guid ServiceId,
    Guid ServiceProviderId,
    DateTime StartDateTime,
    DateTime EndDateTime,
    decimal Price,
    int DurationInMinutes
);
