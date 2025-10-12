using AgendaFacil.Application.DTOs.Request;
using AgendaFacil.Application.DTOs.Response;
using AgendaFacil.Application.Interface;
using AgendaFacil.Application.Interfaces;
using AgendaFacil.Application.Services;
using AgendaFacil.Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaFacil.Api.Controllers;

[Route("api/service")]
[ApiController]
public class ServiceController : BaseController
{
    private readonly IServiceService _serviceService;

    public ServiceController(IServiceService serviceService, NotificationContext notificationContext)
        : base(notificationContext)
    {
        _serviceService = serviceService;
    }

    [HttpPost("create-services")]
    [ProducesResponseType(typeof(Response<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<object>), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateSpeciality([FromBody] ServiceRequestDTO dto, CancellationToken cancellationToken)
    {
        var response = await _serviceService.CreateServiceAsync(dto, cancellationToken);

        return CreateResponse(response);
    }
}
