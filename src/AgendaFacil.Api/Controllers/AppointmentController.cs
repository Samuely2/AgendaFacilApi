using AgendaFacil.Application.DTOs.Request;
using AgendaFacil.Application.DTOs.Response;
using AgendaFacil.Application.Interface;
using AgendaFacil.Application.Interfaces;
using AgendaFacil.Application.Services;
using AgendaFacil.Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaFacil.Api.Controllers;

[Authorize]
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

    [Authorize]
    [HttpPost("create-appointment")]
    [ProducesResponseType(typeof(Response<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<object>), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateAppointment([FromQuery] AppointmentRequestDTO dto, CancellationToken cancellationToken)
    {
        var response = await _appointmentService.CreateAppointment(dto, cancellationToken);

        return CreateResponse(response);
    }

    [Authorize]
    [HttpGet("all")]
    [ProducesResponseType(typeof(Response<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<AppointmentResponseDTO>), StatusCodes.Status201Created)]
    public async Task<IActionResult> GetAllAppointments(CancellationToken cancellationToken)
    {
        var response = await _appointmentService.GetAppointmentsByUserIdAsync(cancellationToken);

        return CreateResponse(response);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(Response<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status201Created)]
    public async Task<IActionResult> DeleteAppointment([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var response = await _appointmentService.DeleteAppointmentsById(id, cancellationToken);

        return CreateResponse(response);
    }
}
