namespace AgendaFacil.Application.Interfaces;

public interface IUserContextService
{
    Guid? UserId { get; set; }
    string? Role { get; set; }
}
