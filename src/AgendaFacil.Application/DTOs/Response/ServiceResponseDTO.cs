namespace AgendaFacil.Application.DTOs.Response;

public record ServiceResponseDTO
(
    string? Name,
    string? Description,
    int DefaultDurationInMinutes,
    decimal DefaultPrice
);
