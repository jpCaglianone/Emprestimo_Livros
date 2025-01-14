using Emprestimo_Livros.Models;
using Usuario.DTO;

namespace Emprestimo_Livros.Service.Interfaces
{
    public interface IUsuarioRegistroService
    {

        ResponseModel<UsuarioModel> RegistrarUsuario(UsuarioRegistroDTO dto);

    }
}
