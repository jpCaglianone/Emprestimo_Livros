using System.ComponentModel.DataAnnotations;

namespace Usuario.DTO
{
    public class UsuarioRegistroDTO
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }


        //colocar o restante dos data anotations

        public string Senha { get; set; }

        [Compare("Senha",ErrorMessage = "As senhas nao sao iguais")]
        public string ConfirmarSenha { get; set; }
    }
}
