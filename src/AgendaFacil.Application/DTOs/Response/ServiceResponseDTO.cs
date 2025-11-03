namespace AgendaFacil.Application.DTOs.Response;

public record ServiceResponseDTO
(
    Guid Id,
    string? Name,
    string? Description,
    int DefaultDurationInMinutes,
    decimal DefaultPrice
);
