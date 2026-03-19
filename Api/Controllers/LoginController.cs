using Api.DTOs;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        private readonly JwtAuthManager _jwtAuthManager;

        public LoginController(UsuarioService usuarioService, JwtAuthManager jwtAuthManager)
        {
            _usuarioService = usuarioService;
            _jwtAuthManager = jwtAuthManager;
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioLoginResponse>> Login([FromBody] UsuarioLoginRequest request)
        {
            var usuario = await _usuarioService.BuscarUsuarioPorEmail(request.Email);

            if (usuario == null || usuario.Senha != request.Senha)
            {
                return Unauthorized(new { mensagem = "Email ou senha incorretos." });
            }

            var token = _jwtAuthManager.GerarToken(usuario.Email);


            var response = new UsuarioLoginResponse
            {
                Id = usuario.Id,
                NomeCompleto = usuario.NomeCompleto,
                Email = usuario.Email,
                Token = token
            };

            return Ok(response);
        }
    }
}