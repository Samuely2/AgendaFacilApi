namespace AgendaFacil.Application.DTOs.Response;

public record ServiceProviderResponseDTO
(
    Guid Id,
    string? Speciality,
    string? Fullname
);
