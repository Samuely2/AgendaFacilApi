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

    [HttpPost("create-service")]
    [ProducesResponseType(typeof(Response<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<object>), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateService([FromBody] ServiceRequestDTO dto, CancellationToken cancellationToken)
    {
        var response = await _serviceService.CreateServiceAsync(dto, cancellationToken);

        return CreateResponse(response);
    }

    [HttpGet("services")]
    [ProducesResponseType(typeof(Response<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<object>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetService(CancellationToken cancellationToken)
    {
        var response = await _serviceService.GetAllServices(cancellationToken);

        return CreateResponse(response);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(Response<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<object>), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteServiceById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var response = await _serviceService.DeleteServiceById(id, cancellationToken);

        return CreateResponse(response);
    }

   
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Response<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<object>), StatusCodes.Status201Created)]
    public async Task<IActionResult> UpdateServiceById([FromRoute] Guid id, [FromBody] ServiceRequestDTO dto, CancellationToken cancellationToken)
    {
        var response = await _serviceService.UpdateServiceById(id, dto, cancellationToken);

        return CreateResponse(response);
    }
}


