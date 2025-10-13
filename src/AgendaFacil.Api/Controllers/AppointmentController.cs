using AgendaFacil.Application.DTOs.Request;
using AgendaFacil.Application.DTOs.Response;
using AgendaFacil.Application.Interface;
using AgendaFacil.Application.Interfaces;
using AgendaFacil.Application.Services;
using AgendaFacil.Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaFacil.Api.Controllers;


[Route("api/appointment")]
[ApiController]
public class AppointmentController : BaseController
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentController(IAppointmentService appointmentService, NotificationContext notificationContext)
        : base(notificationContext)
    {
        _appointmentService = appointmentService;
    }

    [Authorize(Roles = "Client")]
    [HttpPost("create-appointment")]
    [ProducesResponseType(typeof(Response<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<object>), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateSpeciality([FromQuery] AppointmentRequestDTO dto, CancellationToken cancellationToken)
    {
        var response = await _appointmentService.CreateAppointment(dto, cancellationToken);

        return CreateResponse(response);
    }
}
