using AgendaFacil.Domain.Entities;

public class Absence : BaseEntity
{
    public string? Reason { get; set; }
    public DateTime StartDateTime { get; set; } 
    public DateTime EndDateTime { get; set; } 
    public Guid? ServiceProviderProfileId { get; set; }
    public virtual ServiceProviderProfile? ServiceProviderProfile { get; set; }
    public Absence()
    {

    }
}