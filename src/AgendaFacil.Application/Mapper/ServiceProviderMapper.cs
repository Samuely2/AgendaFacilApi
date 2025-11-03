using AgendaFacil.Application.DTOs.Request;
using AgendaFacil.Application.DTOs.Response;
using AgendaFacil.Domain.Entities;

namespace AgendaFacil.Application.Mapper;

public static class ServiceProviderMapper
{
    public static ServiceProviderProfile? DtoToEntity(ServiceProviderRequestDTO dto)
    {
        if (dto == null) return null;

        return new ServiceProviderProfile
        (
            dto.Speciality,
            dto.Fullname            
        );
    }
    public static ServiceProviderResponseDTO? EntityToDto(ServiceProviderProfile? entity)
    {
        if (entity == null) return null;

        return new ServiceProviderResponseDTO
        (
            entity.Id,
            entity.Speciality,
            entity.FullName
        );
    }

    public static List<ServiceProviderResponseDTO> EntityListToDtoList(IEnumerable<ServiceProviderProfile> entities)
    {
        if (entities == null)
            return new List<ServiceProviderResponseDTO>();

        return entities
            .Where(e => e != null)
            .Select(e => new ServiceProviderResponseDTO(
                e.Id,
                e.Speciality,
                e.FullName
            ))
            .ToList();
    }
}
