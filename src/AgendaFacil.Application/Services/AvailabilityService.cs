using AgendaFacil.Application.Interface.Repositories;
using AgendaFacil.Application.Interfaces;

namespace AgendaFacil.Application.Services;

public class AvailabilityService
{
    protected readonly IAvailabilityRepository _availabilityRepository;
    protected readonly IUserContextService _userContextService;
    protected readonly IUnitOfWork _unitOfWork;
    public AvailabilityService(IAvailabilityRepository availabilityRepository, IUserContextService userContextService, IUnitOfWork unitOfWork)
    {
        _availabilityRepository = availabilityRepository;
        _userContextService = userContextService;
        _unitOfWork = unitOfWork;
    }

}
