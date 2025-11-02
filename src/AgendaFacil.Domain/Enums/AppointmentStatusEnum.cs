using System.ComponentModel;

namespace AgendaFacil.Domain.Enums;

public enum AppointmentStatusEnum
{
    [Description("Agendado")]
    Scheduled = 0,

    [Description("Confirmado")]
    Confirmed = 1,

    [Description("Cancelado")]
    Canceled = 2,

    [Description("Completado")]
    Completed = 3
}
