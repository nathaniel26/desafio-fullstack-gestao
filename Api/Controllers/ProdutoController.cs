using Api.DTOs;
using Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    [Authorize]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _service;

        public ProdutoController(ProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutoResponse>>> BuscarProdutos()
        {
            var produtos = await _service.ListarProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoResponse>> BuscarProduto(int id)
        {
            var produto = await _service.BuscarPorId(id);
            if (produto == null) return NotFound();
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoResponse>> CriarProduto([FromForm] ProdutoCreateRequest request)
        {
            try
            {
                string? caminhoImagem = null;

                if (request.Imagem != null)
                {
                    var nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(request.Imagem.FileName);

                    var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

                    if (!Directory.Exists(caminhoPasta))
                        Directory.CreateDirectory(caminhoPasta);

                    var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

                    using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                    {
                        await request.Imagem.CopyToAsync(stream);
                    }

                    caminhoImagem = $"/uploads/{nomeArquivo}";
                }

                var produto = await _service.CriarProduto(request, caminhoImagem);

                return CreatedAtAction(nameof(BuscarProduto), new { id = produto.Id }, produto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarProduto(int id, [FromForm] ProdutoUpdateRequest request)
        {
            try
            {
                string? caminhoImagem = null;

                if (request.Imagem != null)
                {
                    var nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(request.Imagem.FileName);

                    var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

                    if (!Directory.Exists(caminhoPasta))
                        Directory.CreateDirectory(caminhoPasta);

                    var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

                    using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                    {
                        await request.Imagem.CopyToAsync(stream);
                    }

                    caminhoImagem = $"/uploads/{nomeArquivo}";
                }

                var atualizado = await _service.AtualizarProduto(id, request, caminhoImagem);

                if (!atualizado)
                    return NotFound();

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarProduto(int id)
        {
            var deletado = await _service.DeletarProduto(id);
            if (!deletado) return NotFound();
            return NoContent();
        }
    }
}