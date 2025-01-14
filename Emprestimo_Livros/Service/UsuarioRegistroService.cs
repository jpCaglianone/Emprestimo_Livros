using Emprestimo_Livros.Models;
using Emprestimo_Livros.Repository;
using Emprestimo_Livros.Service.Interfaces;
using Usuario.DTO;

namespace Emprestimo_Livros.Service
{
    
    public class UsuarioRegistroService : IUsuarioRegistroService
    {
        private readonly UsuarioRepository _usuarioRepository;
        private readonly ISenhaService _senhaService;
        public UsuarioRegistroService(ISenhaService senhaService, UsuarioRepository usuarioRepository) {
            _senhaService = senhaService;
            _usuarioRepository = usuarioRepository;
        }
        public ResponseModel<UsuarioModel> RegistrarUsuario(UsuarioRegistroDTO dto)
        {

            ResponseModel<UsuarioModel> responseModel = new ResponseModel<UsuarioModel>();

            try
            {
                if (VerificaEmailExiste())
                {
                    responseModel.Mensagem = "Email já cadastrado!";
                    responseModel.Status = false;
                    return responseModel;
                }


                _senhaService.CriarSenhaHash(dto.Senha, out byte[] senhaHash, out byte[] senhaSalt);

                var usuario = new UsuarioModel()
                {
                   Nome = dto.Nome + dto.Sobrenome,
                   Email = dto.Email,
                   senhaHash = senhaHash,
                   senhaSalt = senhaSalt
                };

                if ( _usuarioRepository.RegistrarUsuario(usuario))
                { 
                    responseModel.Mensagem = "Usuário cadastrado com sucesso!";
                }
                else
                {

                    responseModel.Mensagem = "Falha ao cadastrar usuario. Consulte o serviço do sistema!";
                }



                return responseModel;
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
