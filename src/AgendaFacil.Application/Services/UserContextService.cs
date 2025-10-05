using AgendaFacil.Application.Interfaces;

namespace AgendaFacil.Application.Services;

public class UserContextService : IUserContextService
{
    public Guid? UserId { get; set; }
    public string? Role { get; set; }
}
