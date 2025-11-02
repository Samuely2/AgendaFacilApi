namespace AgendaFacil.Domain.Entities;

public class Availability : BaseEntity
{
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public Guid? ServiceProviderProfileId { get; set; }
    public virtual ServiceProviderProfile? ServiceProviderProfile { get; set; }    
    public Availability()
    {

    }

    public Availability(DayOfWeek dayOfWeek, TimeSpan startTime, TimeSpan endTime, ServiceProviderProfile? serviceProviderProfile)
    {
        DayOfWeek = dayOfWeek;
        StartTime = startTime;
        EndTime = endTime;
        ServiceProviderProfile = serviceProviderProfile;
    }
}
