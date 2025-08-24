using AgendaFacil.Domain.Entities;

public class Absence : BaseEntity
{
    public string? Reason { get; set; }
    public DateTime StartDateTime { get; set; } 
    public DateTime EndDateTime { get; set; } 
    public int ServiceProviderId { get; set; }
    public virtual ServiceProvider? ServiceProvider { get; set; }
}