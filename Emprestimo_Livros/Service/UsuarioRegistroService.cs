using Emprestimo_Livros.Models;
using Emprestimo_Livros.Service.Interfaces;
using Usuario.DTO;

namespace Emprestimo_Livros.Service
{
    public class UsuarioRegistroService : IUsuarioRegistroService
    {

        
        public async Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioRegistroDTO dto)
        {

            ResponseModel<UsuarioModel> responseModel = new ResponseModel<UsuarioModel>();

            try
            {
                if (VerificaEmailExiste())
                {

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
            }

            throw new NotImplementedException();
        }


        private bool VerificaEmailExiste()
        {
            return false;
        }

    }

    
}
