using AgendaFacil.Application.DTOs.Response;
using AgendaFacil.Application.Interfaces;
using AgendaFacil.Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaFacil.Api.Controllers;

[Route("api/serviceProvider")]
[Authorize(Roles = "ServiceProvider")]
[ApiController]
public class ServiceProviderController : BaseController
{
    private readonly IServiceProviderService _serviceProviderService;

    public ServiceProviderController(IServiceProviderService serviceProvider, NotificationContext notificationContext)
        : base(notificationContext)
    {
        _serviceProviderService = serviceProvider;
    }

    [HttpPost("specialities")]
    [ProducesResponseType(typeof(Response<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<object>), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateSpeciality([FromBody] string? speciality, CancellationToken cancellationToken)
    {
        var response = await _serviceProviderService.CreateServiceProvider(speciality, cancellationToken);

        return CreateResponse(response);
    }

    [HttpGet("specialities")]
    [ProducesResponseType(typeof(Response<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<object>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSpeciality(CancellationToken cancellationToken)
    {
        var response = await _serviceProviderService.GetSpecialityByUserId(cancellationToken);

        return CreateResponse(response);
    }
}