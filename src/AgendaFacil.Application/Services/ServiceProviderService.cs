using AgendaFacil.Application.DTOs.Request;
using AgendaFacil.Application.DTOs.Response;
using AgendaFacil.Application.Interface.Repositories;
using AgendaFacil.Application.Interfaces;
using AgendaFacil.Application.Mapper;
using AgendaFacil.Domain.Entities;
using AgendaFacil.Domain.Notifications;

namespace AgendaFacil.Application.Services;

public class ServiceProviderService : IServiceProviderService
{
    protected readonly IServiceProviderRepository _serviceProviderRepository;
    protected readonly IUserContextService _userContextService;
    protected readonly IUnitOfWork _unitOfWork;    
    public ServiceProviderService(IServiceProviderRepository serviceProviderRepository, IUserContextService userContextService, IUnitOfWork unitOfWork)
    {
        _serviceProviderRepository = serviceProviderRepository;
        _userContextService = userContextService;
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceProviderResponseDTO?> CreateServiceProvider(ServiceProviderRequestDTO dto, CancellationToken cancellationToken)
    {
        if (dto == null)
        {
            return null;
        }

        Guid? userId = _userContextService.UserId;

        var existingEntity = await _serviceProviderRepository.GetServiceProviderByUserIdAsync(userId, cancellationToken);

        if (existingEntity != null) return null;

        var entity = ServiceProviderMapper.DtoToEntity(dto);

        if (entity == null) return null;

        _serviceProviderRepository.Create(entity);
        await _unitOfWork.Commit(cancellationToken);

        return ServiceProviderMapper.EntityToDto(entity);
    }

    public async Task<List<ServiceProviderResponseDTO>?> GetAllServiceProviders(CancellationToken cancellationToken)
    {
        var entity = await _serviceProviderRepository.GetAll(cancellationToken);

        if (entity is null) return null;

        var dto = ServiceProviderMapper.EntityListToDtoList(entity);

        return dto;
    }
}
