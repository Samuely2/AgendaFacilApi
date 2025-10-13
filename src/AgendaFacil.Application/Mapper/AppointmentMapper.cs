using AgendaFacil.Application.DTOs.Request;
using AgendaFacil.Application.DTOs.Response;
using AgendaFacil.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

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
}

