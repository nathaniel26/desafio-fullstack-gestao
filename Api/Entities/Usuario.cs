using System.ComponentModel.DataAnnotations;
namespace Api.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NomeCompleto { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Senha { get; set; } = null!;
    }
}