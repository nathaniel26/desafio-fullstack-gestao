using Api.DTOs;
using Api.Entities;
using Api.Repositories;

namespace Api.Services
{
    public class ProdutoService
    {
        private readonly ProdutoRepository _repository;

        public ProdutoService(ProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProdutoResponse>> ListarProdutos()
        {
            var produtos = await _repository.ListarProdutos();
            return produtos.Select(p => new ProdutoResponse
            {
                Id = p.Id,
                Titulo = p.Titulo,
                Descricao = p.Descricao,
                Quantidade = p.Quantidade,
                ImagemUrl = p.ImagemUrl
            }).ToList();
        }

        public async Task<ProdutoResponse?> BuscarPorId(int id)
        {
            var produto = await _repository.BuscarPorId(id);
            if (produto == null) return null;

            return new ProdutoResponse
            {
                Id = produto.Id,
                Titulo = produto.Titulo,
                Descricao = produto.Descricao,
                Quantidade = produto.Quantidade,
                ImagemUrl = produto.ImagemUrl
            };
        }

        public async Task<ProdutoResponse> CriarProduto(ProdutoCreateRequest request, string? imagemUrl)
        {
            if (request.Quantidade < 0)
                throw new ArgumentException("A quantidade em estoque não pode ser negativa.");

            var produto = new Produto
            {
                Titulo = request.Titulo,
                Descricao = request.Descricao,
                Quantidade = request.Quantidade,
                ImagemUrl = imagemUrl
            };

            await _repository.AdicionarProduto(produto);

            return new ProdutoResponse
            {
                Id = produto.Id,
                Titulo = produto.Titulo,
                Descricao = produto.Descricao,
                Quantidade = produto.Quantidade,
                ImagemUrl = produto.ImagemUrl
            };
        }

        public async Task<bool> AtualizarProduto(int id, ProdutoUpdateRequest request, string? imagemUrl)
        {
            var produto = await _repository.BuscarPorId(id);
            if (produto == null) return false;

            if (request.Quantidade < 0)
                throw new ArgumentException("A quantidade em estoque não pode ser negativa.");

            produto.Titulo = request.Titulo;
            produto.Descricao = request.Descricao;
            produto.Quantidade = request.Quantidade;

            if (imagemUrl != null)
            {
                produto.ImagemUrl = imagemUrl;
            }

            await _repository.AtualizarProduto(produto);
            return true;
        }

        public async Task<bool> DeletarProduto(int id)
        {
            var produto = await _repository.BuscarPorId(id);
            if (produto == null) return false;

            if (!string.IsNullOrEmpty(produto.ImagemUrl))
            {
                var caminhoArquivo = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    produto.ImagemUrl.TrimStart('/')
                );

                if (File.Exists(caminhoArquivo))
                {
                    File.Delete(caminhoArquivo);
                }
            }

            await _repository.DeletarProduto(produto);
            return true;
        }
    }
}