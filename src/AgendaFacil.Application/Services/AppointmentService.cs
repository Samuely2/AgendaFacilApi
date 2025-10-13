using AgendaFacil.Application.DTOs.Request;
using AgendaFacil.Application.Interface;
using AgendaFacil.Application.Interface.Repositories;
using AgendaFacil.Application.Interfaces;
using AgendaFacil.Application.Mapper;
using AgendaFacil.Domain.Entities;
using System.Threading;

namespace AgendaFacil.Application.Services;

public class AppointmentService : IAppointmentService
{
    protected readonly IAppointmentRepository _appointmentRepository;
    protected readonly IUserContextService _userContextService;
    protected readonly IUnitOfWork _unitOfWork;
    public AppointmentService(IAppointmentRepository appointmentRepository, IUserContextService userContextService, IUnitOfWork unitOfWork)
    {
        _appointmentRepository = appointmentRepository;
        _userContextService = userContextService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Appointment?> CreateAppointment(AppointmentRequestDTO dto, CancellationToken cancellationToken)
    {
        if (dto == null) return null;

        var userId = _userContextService.UserId ?? Guid.Empty;

        var entity = AppointmentMapper.DtoToEntity(dto, userId);

        if (entity == null)
        {
            return null;
        }

        _appointmentRepository.Create(entity);
        await _unitOfWork.Commit(cancellationToken);
        return entity;
    }
}
