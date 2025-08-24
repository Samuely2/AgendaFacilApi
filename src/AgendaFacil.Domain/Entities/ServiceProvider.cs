namespace AgendaFacil.Domain.Entities;

//Represents the person or business offering the services.

public class ServiceProvider : BaseEntity
{
    public string? Name { get; set; }
    public string? Speciality { get; set; }
    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    public virtual ICollection<Availability> Availabilities { get; set; } = new List<Availability>();
}
