using AgendaFacil.Application.Interface.Repositories;
using AgendaFacil.Application.Interfaces;
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

    public async Task<string?> CreateServiceProvider(string? speciality, CancellationToken cancellationToken)
    {
        if (speciality == null)
        {
            return null;
        }

        Guid? userId = _userContextService.UserId;

        var entity = new ServiceProviderProfile
        {
            UserId = userId,
            Speciality = speciality
            
        };

        _serviceProviderRepository.Create(entity);
        await _unitOfWork.Commit(cancellationToken);
        return entity.Speciality;
    }

    public async Task<List<string?>?> GetSpecialityByUserId(CancellationToken cancellationToken)
    {
        Guid? userId = _userContextService.UserId;

        var speciality = await _serviceProviderRepository.GetSpecialityByUserId(userId, cancellationToken);

        if (speciality is null)
        {
            return null;
        }

        return speciality;
    }
   
    public async Task<List<ServiceProviderProfile>?> GetServiceProviderByUserId(CancellationToken cancellationToken)
    {
        Guid? userId = _userContextService.UserId;

        var entity = await _serviceProviderRepository.GetServiceProviderByUserIdAsync(userId, cancellationToken);

        if (entity is null) return null;

        return entity;
    }
}
