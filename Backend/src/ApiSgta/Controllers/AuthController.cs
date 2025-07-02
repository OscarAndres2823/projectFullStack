using Application.Interfaces;
using Infrastructure.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiSgta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly JwtTokenService _jwtService;

        public AuthController(IUsuarioRepository usuarioRepo, JwtTokenService jwtService)
        {
            _usuarioRepo = usuarioRepo;
            _jwtService = jwtService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var usuario = await _usuarioRepo.GetByCorreoAsync(request.Correo!);
            if (usuario == null || usuario.Password != request.Password)
            {
                return Unauthorized("Credenciales inválidas");
            }

            var token = _jwtService.GenerateToken(usuario.Correo!);
            return Ok(new { token });
        }
    }

    public class LoginRequest
    {
        public string? Correo { get; set; }
        public string? Password { get; set; }
    }
}
