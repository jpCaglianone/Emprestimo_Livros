using Emprestimo_Livros.Models;
using Emprestimo_Livros.Service.Interfaces;
using Usuario.DTO;

namespace Emprestimo_Livros.Service
{
    public class UsuarioRegistroService : IUsuarioRegistroService
    {
        public Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioRegistroDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
