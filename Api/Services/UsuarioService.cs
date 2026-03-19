using Api.DTOs;
using Api.Entities;
using Api.Repositories;

namespace Api.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _repository;

        public UsuarioService(UsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<UsuarioResponse>> ListarUsuarios()
        {
            var usuarios = await _repository.ListarUsuarios();
            return usuarios.Select(u => new UsuarioResponse
            {
                Id = u.Id,
                NomeCompleto = u.NomeCompleto,
                Email = u.Email
            }).ToList();
        }

        public async Task<UsuarioResponse> BuscarUsuarioPorId(int id)
        {
            var usuario = await _repository.BuscarPorId(id);
            if (usuario == null)
                throw new KeyNotFoundException("Usuário não encontrado.");

            return new UsuarioResponse
            {
                Id = usuario.Id,
                NomeCompleto = usuario.NomeCompleto,
                Email = usuario.Email
            };
        }

        public async Task<Usuario?> BuscarUsuarioPorEmail(string email)
        {
            return await _repository.BuscarPorEmail(email);
        }

        public async Task<UsuarioResponse> CriarUsuario(UsuarioCreateRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.NomeCompleto))
                throw new ArgumentException("O nome completo é obrigatório.");

            if (string.IsNullOrWhiteSpace(request.Email) || !request.Email.Contains("@"))
                throw new ArgumentException("O email é inválido.");

            if (string.IsNullOrWhiteSpace(request.Senha) || request.Senha.Length < 6)
                throw new ArgumentException("A senha é obrigatória e deve ter no mínimo 6 caracteres.");

            var usuarioExistente = await _repository.BuscarPorEmail(request.Email);
            if (usuarioExistente != null)
                throw new ArgumentException("Já existe um usuário com esse email.");

            var usuario = new Usuario
            {
                NomeCompleto = request.NomeCompleto,
                Email = request.Email,
                Senha = request.Senha
            };

            await _repository.AdicionarUsuario(usuario);

            return new UsuarioResponse
            {
                Id = usuario.Id,
                NomeCompleto = usuario.NomeCompleto,
                Email = usuario.Email
            };
        }

        public async Task AtualizarUsuario(int id, UsuarioUpdateRequest request)
        {
            var usuario = await _repository.BuscarPorId(id);
            if (usuario == null)
                throw new KeyNotFoundException("Usuário não encontrado.");

            var usuarioComMesmoEmail = await _repository.BuscarPorEmail(request.Email);
            if (usuarioComMesmoEmail != null && usuarioComMesmoEmail.Id != id)
                throw new ArgumentException("Já existe outro usuário com esse email.");


            usuario.NomeCompleto = request.NomeCompleto;
            usuario.Email = request.Email;

            await _repository.AtualizarUsuario(usuario);
        }

        public async Task DeletarUsuario(int id)
        {
            var usuario = await _repository.BuscarPorId(id);
            if (usuario == null)
                throw new KeyNotFoundException("Usuário não encontrado.");

            await _repository.DeletarUsuario(usuario);
        }
    }
}