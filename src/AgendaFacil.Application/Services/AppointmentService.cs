using AgendaFacil.Application.DTOs.Request;
using AgendaFacil.Application.DTOs.Response;
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

    public async Task<List<AppointmentResponseDTO>?> GetAppointmentsByUserIdAsync(CancellationToken cancellationToken)
    {
        Guid? userId = _userContextService.UserId;
        string? role = _userContextService.Role;

        var entity = await _appointmentRepository.GetAppointmentsByUserIdAsync(userId, role, cancellationToken);

        if (entity is null) return null;

        var dto = AppointmentMapper.EntityListToDtoList(entity);

        return dto;
 
    }

    public async Task<bool> DeleteAppointmentsById(Guid appointmentId, CancellationToken cancellationToken)
    {
        Guid? userId = _userContextService.UserId;
        string? role = _userContextService.Role;

        var appointment = await _appointmentRepository.GetAppointmentByid(appointmentId, cancellationToken);

        if (appointment == null)
        {
            return false;
        } 

        _appointmentRepository.Delete(appointment);
        await _unitOfWork.Commit(cancellationToken);

        return true;
    }
 }
