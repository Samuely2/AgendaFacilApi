namespace AgendaFacil.Domain.Entities;

public class Service : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int DefaultDurationInMinutes { get; set; }
    public decimal DefaultPrice { get; set; }
    public virtual ICollection<ServiceProvider>? ServiceProviders { get; set; }
}
