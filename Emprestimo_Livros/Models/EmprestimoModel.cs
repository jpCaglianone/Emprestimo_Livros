using System.ComponentModel.DataAnnotations.Schema;

namespace Emprestimo_Livros.Models
{
    [Table("EmprestimoLivros")]
    public class EmprestimoModel
    {
        public int Id { get; set; }
        public string RecebedorNome { get; set; }
        public string FornecedorNome { get; set; }
        public string LivroEmprestadoNome { get; set; }
        public DateTime DataEmprestimoLivro {  get; set; } = DateTime.Now; //sempre será o horario que o registro de emprestimo for efetivado


    }
}
