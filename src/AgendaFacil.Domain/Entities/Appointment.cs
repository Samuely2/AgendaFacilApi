using System.ComponentModel.DataAnnotations.Schema;
using AgendaFacil.Domain.Enums;

namespace AgendaFacil.Domain.Entities;
public class Appointment : BaseEntity
{
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public AppointmentStatusEnum Status { get; set; }
    public virtual User User { get; set; } = new User();
    public virtual Service Service { get; set; } = new Service();
    public virtual ServiceProvider ServiceProvider { get; set; } = new ServiceProvider();
}

