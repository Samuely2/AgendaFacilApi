using AgendaFacil.Api.Controllers;
using AgendaFacil.Application.DTOs.Request;
using AgendaFacil.Domain.Authentication;
using AgendaFacil.Domain.Notifications;
using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole<Guid>> roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<Guid>> roleManager,
            IConfiguration configuration, NotificationContext notificationContext) : base(notificationContext)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(Response<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<object>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO dto)
        {
            var user = await userManager.FindByEmailAsync(dto.Email);
            if (user != null && await userManager.CheckPasswordAsync(user, dto.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                    var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email!),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };                           

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }
        
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(typeof(Response<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<object>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Register([FromBody] CreateUserRequestDTO dto)
        {
            var userExists = await userManager.FindByEmailAsync(dto.Email);
            if (userExists != null)
            {
                _notificationContext.AddNotification("Usuário", "Usuário ja existe");                
            }

             ApplicationUser user = new ApplicationUser()
            {
                Email = dto.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = dto.Username       
            };
            var result = await userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                _notificationContext.AddNotification("Erro", "Ocorreu um problema na criação do usuário");
            }          

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, dto.Role);
            }

            return CreateResponse(result, 200);

        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] CreateUserRequestDTO dto)
        {
            var userExists = await userManager.FindByNameAsync(dto.Username);
            if (userExists != null)
            {
                _notificationContext.AddNotification("Usuário", "Usuário ja existe");
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = dto.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = dto.Username
            };
            var result = await userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                _notificationContext.AddNotification("Erro", "Erro ao criar o usuário");
            }

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole<Guid>(UserRoles.Admin));

            if (!await roleManager.RoleExistsAsync(UserRoles.Client))
                await roleManager.CreateAsync(new IdentityRole<Guid>(UserRoles.Client));

            if (!await roleManager.RoleExistsAsync(UserRoles.ServiceProvider))
                await roleManager.CreateAsync(new IdentityRole<Guid>(UserRoles.ServiceProvider));

            if (await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            return CreateResponse(result, 200);
        }
    }
}