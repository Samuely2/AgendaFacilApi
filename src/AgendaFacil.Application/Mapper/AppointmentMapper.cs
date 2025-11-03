using AgendaFacil.Application.DTOs.Request;
using AgendaFacil.Application.DTOs.Response;
using AgendaFacil.Domain.Entities;

namespace AgendaFacil.Application.Mapper;

public static class AppointmentMapper
{
    public static Appointment? DtoToEntity(AppointmentRequestDTO dto, Guid userId)
    {
        if (dto == null) return null;

        return new Appointment
        (
            dto.ServiceId,
            dto.ServiceProviderId,
            userId,
            dto.StartDateTime,
            dto.EndDateTime,
            dto.Price,
            dto.DurationInMinutes
        );
    }
    public static AppointmentResponseDTO? EntityToDto(Appointment entity)
    {
        if (entity == null) return null;

        return new AppointmentResponseDTO
        (
            entity.Id,
            entity.ServiceId,
            entity.ServiceProviderId,
            entity.StartDateTime,
            entity.EndDateTime,
            entity.Status,
            entity.Price,
            entity.DurationInMinutes
        );
    }

    public static List<AppointmentResponseDTO> EntityListToDtoList(IEnumerable<Appointment> entities)
    {
        if (entities == null)
            return new List<AppointmentResponseDTO>();

        return entities
            .Where(e => e != null)
            .Select(e => new AppointmentResponseDTO(
                e.Id,
                e.ServiceId,
                e.ServiceProviderId,
                e.StartDateTime,
                e.EndDateTime,
                e.Status,
                e.Price,
                e.DurationInMinutes
            ))
            .ToList();
    }
}

