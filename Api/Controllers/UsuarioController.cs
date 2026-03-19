using Api.DTOs;
using Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UsuariosController(UsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioResponse>>> BuscarUsuarios()
        {
            return Ok(await _service.ListarUsuarios());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioResponse>> BuscarUsuarioPorId(int id)
        {
            try
            {
                var usuario = await _service.BuscarUsuarioPorId(id);
                return Ok(usuario);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { erro = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<UsuarioResponse>> CriarUsuario(UsuarioCreateRequest request)
        {
            try
            {
                var usuario = await _service.CriarUsuario(request);
                return CreatedAtAction(nameof(BuscarUsuarioPorId), new { id = usuario.Id }, usuario);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpPut("usuarios/{id}")]
        public async Task<IActionResult> AtualizarUsuario(int id, UsuarioUpdateRequest request)
        {
            try
            {
                await _service.AtualizarUsuario(id, request);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { erro = ex.Message });
            }
        }

        [HttpDelete("usuarios/{id}")]
        public async Task<IActionResult> DeletarUsuario(int id)
        {
            try
            {
                await _service.DeletarUsuario(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { erro = ex.Message });
            }
        }
    }
}