using AgendaFacil.Domain.Enums;

namespace AgendaFacil.Domain.Entities;
public class Appointment : BaseEntity
{
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public AppointmentStatusEnum Status { get; set; }
    public decimal Price { get; set; }
    public int DurationInMinutes { get; set; }
    public Guid UserId { get; set; }
    public virtual ApplicationUser? User { get; set; }
    public Guid ServiceId { get; set; }
    public virtual Service? Service { get; set; }
    public Guid? ServiceProviderId { get; set; }
    public virtual ServiceProviderProfile? ServiceProvider { get; set; }

}

