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

    public Appointment()
    {

    }

    public Appointment(DateTime startDateTime, DateTime endDateTime, AppointmentStatusEnum status, decimal price, int durationInMinutes, Guid userId, ApplicationUser? user, Guid serviceId, Service? service, Guid? serviceProviderId, ServiceProviderProfile? serviceProvider)
    {
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Status = status;
        Price = price;
        DurationInMinutes = durationInMinutes;
        UserId = userId;
        User = user;
        ServiceId = serviceId;
        Service = service;
        ServiceProviderId = serviceProviderId;
        ServiceProvider = serviceProvider;
    }
}

