using AgendaFacil.Api.Controllers;
using AgendaFacil.Application.DTOs.Request;
using AgendaFacil.Domain.Entities.Authentication;
using AgendaFacil.Domain.Notifications;
using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthenticateController(
               UserManager<ApplicationUser> userManager,
               RoleManager<IdentityRole<Guid>> roleManager,
               SignInManager<ApplicationUser> signInManager,
               IConfiguration configuration,
               NotificationContext notificationContext) : base(notificationContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(Response<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<object>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null) return Unauthorized("Usuário não encontrado");

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            if (!result.Succeeded) return Unauthorized("Credenciais inválida");

            
              var roles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {

                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };    

                foreach (var userRole in roles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));

                var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddHours(3),                    
                    claims: authClaims,
                    audience: _configuration["JWT:ValidAudience"],
                    issuer: _configuration["JWT:ValidIssuer"],
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    roles
                });                        
        }
        
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(typeof(Response<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<object>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Register([FromBody] CreateUserRequestDTO dto)
        {
            var userExists = await _userManager.FindByEmailAsync(dto.Email);

            if (userExists != null)
            {
                _notificationContext.AddNotification("Usuário", "Usuário ja existe");                
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = dto.Email,
                FullName = dto.Fullname,
                UserName = dto.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                _notificationContext.AddNotification("Erro", $"Ocorreu um problema na criação do usuário: {result.Errors.ToString}");
            }          

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, dto.Role);
            }

            return CreateResponse(result, 200);

        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromQuery] string email, [FromQuery] string password)
        {
            var userExists = await _userManager.FindByEmailAsync(email);
            if (userExists != null)
            {
                _notificationContext.AddNotification("Usuário", "Usuário ja existe");
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = email,
                UserName = email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                _notificationContext.AddNotification("Erro", "Erro ao criar o usuário");
            }

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole<Guid>(UserRoles.Admin));

            if (!await _roleManager.RoleExistsAsync(UserRoles.Client))
                await _roleManager.CreateAsync(new IdentityRole<Guid>(UserRoles.Client));

            if (!await _roleManager.RoleExistsAsync(UserRoles.ServiceProvider))
                await _roleManager.CreateAsync(new IdentityRole<Guid>(UserRoles.ServiceProvider));

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            return CreateResponse(result, 200);
        }
    }
}