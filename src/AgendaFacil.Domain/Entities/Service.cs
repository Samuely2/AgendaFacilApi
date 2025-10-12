namespace AgendaFacil.Domain.Entities;

public class Service : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int DefaultDurationInMinutes { get; set; }
    public decimal DefaultPrice { get; set; }
    public virtual ICollection<ServiceProviderProfile>? ServiceProviders { get; set; }
    public Service()
    {

    }

    public Service(string? name, string? description, int defaultDurationInMinutes, decimal defaultPrice)
    {
        Name = name;
        Description = description;
        DefaultDurationInMinutes = defaultDurationInMinutes;
        DefaultPrice = defaultPrice;
    }   
}
