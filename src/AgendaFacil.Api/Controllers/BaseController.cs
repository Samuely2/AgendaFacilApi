using AgendaFacil.Application.DTOs.Response;
using AgendaFacil.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace AgendaFacil.Api.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly NotificationContext _notificationContext;

        protected BaseController(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        protected IActionResult CreateResponse<T>(T data, int statusCode = StatusCodes.Status200OK)
        {
            if (_notificationContext.HasNotifications)
            {
                return BadRequest(new Response<object>
                {
                    Success = false,
                    Data = null,
                    Notifications = _notificationContext.Notifications
                });
            }

            if (statusCode == StatusCodes.Status201Created)
            {
                return Created(string.Empty, new Response<T>
                {
                    Success = true,
                    Data = data,
                    Notifications = null
                });
            }

            if (statusCode == StatusCodes.Status404NotFound)
            {
                return NotFound(new Response<T>
                {
                    Success = false,
                    Data = data,
                    Notifications = null
                });
            }

            if (statusCode == StatusCodes.Status204NoContent)
            {
                return NoContent();
            }

            return Ok(new Response<T>
            {
                Success = true,
                Data = data,
                Notifications = null
            });
        }
    }
}
