using System.ComponentModel.DataAnnotations;
namespace Api.Entities
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; } = null!;
        [Required]
        public string Descricao { get; set; } = null!;
        public int Quantidade { get; set; }
        [Required]
        public string ImagemUrl { get; set; } = null!;
    }
}
