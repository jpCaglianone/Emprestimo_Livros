using Emprestimo_Livros.Models;
using Usuario.DTO;

namespace Emprestimo_Livros.Service.Interfaces
{
    public interface IUsuarioRegistroService
    {

        Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioRegistroDTO dto);

    }
}
