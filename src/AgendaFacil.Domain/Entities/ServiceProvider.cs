namespace AgendaFacil.Domain.Entities;

public class ServiceProvider : BaseEntity
{
    public Guid UserId { get; set; } 
    public virtual ApplicationUser? User { get; set; }
    public string? Speciality { get; set; }
    public virtual ICollection<Service>? Services { get; set; }
    public virtual ICollection<Appointment>? Appointments { get; set; }
    public virtual ICollection<Availability>? Availabilities { get; set; }
    public virtual ICollection<Absence>? Absences { get; set; }
}