using AgendaFacil.Domain.Notifications;
namespace AgendaFacil.Application.DTOs.Response;
public class Response<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public IEnumerable<Notification>? Notifications { get; set; }
}
