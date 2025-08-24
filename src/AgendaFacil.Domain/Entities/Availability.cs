namespace AgendaFacil.Domain.Entities;

public class Availability : BaseEntity
{
    public DayOfWeek DayOfWeek { get; set; } // Monday, Tuesday, etc.
    public TimeSpan StartTime { get; set; } // E.g., 09:00
    public TimeSpan EndTime { get; set; }   // E.g., 18:00
    public virtual ServiceProvider ServiceProvider { get; set; } = new ServiceProvider();
}
