using AgendaFacil.Application.DTOs.Request;
using AgendaFacil.Application.DTOs.Response;
using AgendaFacil.Application.Interface;
using AgendaFacil.Application.Interface.Repositories;
using AgendaFacil.Application.Interfaces;
using AgendaFacil.Application.Mapper;
using AgendaFacil.Domain.Entities;

namespace AgendaFacil.Application.Services;

public class ServiceService : IServiceService
{
    protected readonly IServiceRepository _serviceRepository;
    protected readonly IUserContextService _userContextService;
    protected readonly IUnitOfWork _unitOfWork;
    public ServiceService(IServiceRepository serviceRepository, IUserContextService userContextService, IUnitOfWork unitOfWork)
    {
        _serviceRepository = serviceRepository;
        _userContextService = userContextService;
        _unitOfWork = unitOfWork;
    }
    public async Task<Service?> CreateServiceAsync(ServiceRequestDTO dto, CancellationToken cancellationToken)
    {
        if (dto == null)
        {
            return null;
        }

        var entity = ServiceMapper.DtoToEntity(dto);

        if (entity == null)
        {
            return null;
        }

        _serviceRepository.Create(entity);
        await _unitOfWork.Commit(cancellationToken);
        return entity;
    }
}
