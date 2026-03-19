namespace Api.DTOs
{
    public class UsuarioCreateRequest
    {
        public string NomeCompleto { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;
    }

    public class UsuarioUpdateRequest
    {
        public string NomeCompleto { get; set; } = null!;
        public string Email { get; set; } = null!;
    }

    public class UsuarioResponse
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; } = null!;
        public string Email { get; set; } = null!;
    }

    public class UsuarioLoginRequest
    {
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;
    }

    public class UsuarioLoginResponse
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}