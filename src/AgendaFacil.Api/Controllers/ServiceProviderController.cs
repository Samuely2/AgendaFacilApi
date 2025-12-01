using AgendaFacil.Application.DTOs.Request;
using AgendaFacil.Application.DTOs.Response;
using AgendaFacil.Application.Interfaces;
using AgendaFacil.Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaFacil.Api.Controllers;

[Route("api/serviceProvider")]
[ApiController]
public class ServiceProviderController : BaseController
{
    private readonly IServiceProviderService _serviceProviderService;
     
    public ServiceProviderController(IServiceProviderService serviceProvider, NotificationContext notificationContext)
        : base(notificationContext)
    {
        _serviceProviderService = serviceProvider;
    }

    [HttpPost()]
    [ProducesResponseType(typeof(Response<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<ServiceProviderResponseDTO>), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateServiceProvider([FromBody] ServiceProviderRequestDTO dto, CancellationToken cancellationToken)
    {
        var response = await _serviceProviderService.CreateServiceProvider(dto, cancellationToken);

        if (response == null)
        {
            _notificationContext.AddNotification("Usuário", "Usuário atual já é um prestador de serviços");
            return CreateResponse(response);
        }

        return CreateResponse(response);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Response<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<List<ServiceProviderResponseDTO>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetServiceProvider([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var response = await _serviceProviderService.GetServiceProviderById(id, cancellationToken);

        if (response == null)
        {
            _notificationContext.AddNotification("Id", "Prestador de serviços não encontrado com o Id informado");
            return CreateResponse(response);
        }

        return CreateResponse(response);
    }

    [HttpGet("all")]
    [ProducesResponseType(typeof(Response<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<List<ServiceProviderResponseDTO>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetServiceProvider(CancellationToken cancellationToken)
    {
        var response = await _serviceProviderService.GetAllServiceProviders(cancellationToken);

        return CreateResponse(response);
    }
}