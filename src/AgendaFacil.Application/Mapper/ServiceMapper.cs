using AgendaFacil.Application.DTOs.Request;
using AgendaFacil.Application.DTOs.Response;
using AgendaFacil.Domain.Entities;
using System.Reflection.Metadata.Ecma335;

namespace AgendaFacil.Application.Mapper;

public static class ServiceMapper
{
    public static Service? DtoToEntity(ServiceRequestDTO dto)
    {
        if (dto == null) return null;

        return new Service
        (
            dto.Name,
            dto.Description,
            dto.DefaultDurationInMinutes,
            dto.DefaultPrice
        );
    }
    
    public static ServiceResponseDTO? EntityToDto(Service entity)
    {
        if (entity == null) return null;

        return new
        (
            entity.Name,
            entity.Description,
            entity.DefaultDurationInMinutes,
            entity.DefaultPrice
        );
    }
}
