using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emprestimo_Livros.Models
{
    [Table("Usuarios")]
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        public byte[] senhaHash { get; set; } //criptografa a senha
        public byte[] senhaSalt { get; set; } //mesmo que duas senhas sejam iguais, o hash sera igual,
                                              //mas o salt nao será, pois vai gerar uma chave diferente


    }
}
