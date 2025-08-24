using AgendaFacil.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AgendaFacilDbContext : IdentityDbContext<User,IdentityRole<int>, int>
{
    public AgendaFacilDbContext(DbContextOptions<AgendaFacilDbContext> options)
        : base(options) { }

    public DbSet<ServiceProvider> ServiceProviderProfiles { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Availability> Availabilities { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);

    }
}