using AgendaFacil.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AgendaFacilDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public AgendaFacilDbContext(DbContextOptions<AgendaFacilDbContext> options)
        : base(options) { }

    public DbSet<ServiceProviderProfile> ServiceProviderProfiles { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Availability> Availabilities { get; set; }
    public DbSet<Absence> Absences { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        {
            property.SetColumnType("decimal(18, 2)");
        }

        builder.Entity<ApplicationUser>()
               .HasOne(u => u.ServiceProviderProfile)
               .WithOne(sp => sp.User)
               .HasForeignKey<ServiceProviderProfile>(sp => sp.UserId);

        builder.Entity<ServiceProviderProfile>()
            .HasMany(sp => sp.Absences)
            .WithOne(a => a.ServiceProviderProfile)
            .HasForeignKey(a => a.ServiceProviderProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Appointment>(entity =>
        {
            entity.HasOne(a => a.User)
                  .WithMany(u => u.Appointments)
                  .HasForeignKey(a => a.UserId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(a => a.ServiceProvider)
                  .WithMany(sp => sp.Appointments)
                  .HasForeignKey(a => a.ServiceProviderId)
                  .OnDelete(DeleteBehavior.Restrict); 

            entity.HasOne(a => a.Service)
                  .WithMany()
                  .HasForeignKey(a => a.ServiceId)
                  .OnDelete(DeleteBehavior.Restrict);
        });       
    }

}