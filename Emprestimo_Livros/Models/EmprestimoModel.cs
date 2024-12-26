using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emprestimo_Livros.Models
{
    [Table("EmprestimoLivros")]
    public class EmprestimoModel
    {
     
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do recebedor")]
        public string RecebedorNome { get; set; }
        [Required(ErrorMessage = "Digite o nome do recebedor")]
        public string FornecedorNome { get; set; }
        [Required(ErrorMessage = "Digite o nome do recebedor")]
        public string LivroEmprestadoNome { get; set; }
        [Required(ErrorMessage = "Digite o nome do recebedor")]
        public DateTime DataEmprestimoLivro {  get; set; } = DateTime.Now; //sempre será o horario que o registro de emprestimo for efetivado
        public string Status { get; set; }

    }
}
