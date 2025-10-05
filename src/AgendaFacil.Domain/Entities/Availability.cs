namespace AgendaFacil.Domain.Entities;

public class Availability : BaseEntity
{
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public virtual ServiceProviderProfile? ServiceProviderProfile { get; set; }
}
