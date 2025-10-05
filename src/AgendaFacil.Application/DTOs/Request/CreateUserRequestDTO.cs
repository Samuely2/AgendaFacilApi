using System;
using System.ComponentModel.DataAnnotations;

namespace AgendaFacil.Application.DTOs.Request
{
    public class CreateUserRequestDTO
    {          
        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; } = string.Empty;

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Fullname is required")]
        public string Fullname { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;
    }
}

