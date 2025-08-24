using System.ComponentModel.DataAnnotations;
namespace AgendaFacil.Application.DTOs.Request;

public class LoginRequestDTO
{
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = string.Empty;
}
