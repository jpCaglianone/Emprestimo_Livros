using Emprestimo_Livros.DTO;
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


        public ResponseModel<UsuarioModel> LoginUsuario(LoginDTO dto) 
        {

            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();

            try
            {
                var usuario = _usuarioRepository.ProcuraUsuarioEmail(dto.Email);
                if ((usuario != null) ||
                (!_senhaService.VerificaSenha(dto.Senha, usuario.senhaSalt, usuario.senhaHash)))
                {
                    response.Mensagem = "Credenciais invalidas!";
                    response.Status = false;
                    return response;
                }

                response.Mensagem = "Usuario logado com sucesso!";
                return response;    
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }

        }

        private bool VerificaEmailExiste()
        {
            return false;
        }

    }

    
}
