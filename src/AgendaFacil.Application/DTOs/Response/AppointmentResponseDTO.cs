using AgendaFacil.Domain.Enums;

namespace AgendaFacil.Application.DTOs.Response;

public record AppointmentResponseDTO
(
   Guid Id,
   Guid ServiceId,
   Guid? ServiceProviderId,
   DateTime StartDateTime,  
   DateTime EndDateTime,
   AppointmentStatusEnum Status,
   decimal Price, 
   int DurationInMinutes
);
