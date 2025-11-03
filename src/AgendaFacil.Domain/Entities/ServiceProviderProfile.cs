namespace AgendaFacil.Domain.Entities;

public class ServiceProviderProfile : BaseEntity
{
    public Guid? UserId { get; set; } 
    public virtual ApplicationUser? User { get; set; }
    public string? Speciality { get; set; }
    public string? FullName { get; set; }
    public virtual ICollection<Service>? Services { get; set; }
    public virtual ICollection<Appointment>? Appointments { get; set; }
    public virtual ICollection<Availability>? Availabilities { get; set; }
    public virtual ICollection<Absence>? Absences { get; set; }

    public ServiceProviderProfile()
    {
    }

    public ServiceProviderProfile(Guid? userId, string? speciality, string? fullName)
    {
        UserId = userId;
        Speciality = speciality;
        FullName = fullName;
    }

    public ServiceProviderProfile(string? speciality, string? fullName)
    {
        Speciality = speciality;
        FullName = fullName;
    }
}