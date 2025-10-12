namespace AgendaFacil.Application.DTOs.Request;

public record ServiceRequestDTO
(
    string? Name,
    string? Description,
    int DefaultDurationInMinutes,
    decimal DefaultPrice
);
