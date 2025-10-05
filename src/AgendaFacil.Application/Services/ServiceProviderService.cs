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
}
