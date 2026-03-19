namespace Api.DTOs
{
    public class ProdutoCreateRequest
    {
        public string Titulo { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public int Quantidade { get; set; }

        public IFormFile? Imagem { get; set; }
    }

    public class ProdutoUpdateRequest
    {
        public string Titulo { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public int Quantidade { get; set; }
         public IFormFile? Imagem { get; set; }
    }

    public class ProdutoResponse
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public int Quantidade { get; set; }
        public string ImagemUrl { get; set; } = null!;
    }
}