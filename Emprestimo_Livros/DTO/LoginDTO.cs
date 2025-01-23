using System.ComponentModel.DataAnnotations;

namespace Emprestimo_Livros.DTO
{
    public class LoginDTO
    {

        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
