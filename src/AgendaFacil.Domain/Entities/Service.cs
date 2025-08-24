using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaFacil.Domain.Entities;

public class Service : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int DurationInMinutes { get; set; }
    public decimal Price { get; set; }
    public virtual ServiceProvider ServiceProvider { get; set; } = new ServiceProvider();
}
