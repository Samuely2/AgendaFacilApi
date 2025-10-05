using AgendaFacil.Domain.Entities;
using Microsoft.AspNetCore.Identity;
public class ApplicationUser : IdentityUser<Guid>
{
    public string? FullName { get; set; }
    public virtual ICollection<Appointment>? Appointments { get; set; }
    public virtual ServiceProviderProfile? ServiceProviderProfile { get; set; }

    public ApplicationUser()
    {

    }
}

