using Emprestimo_Livros.Models;
using Emprestimo_Livros.Service.Interfaces;
using Newtonsoft.Json;

namespace Emprestimo_Livros.Service
{
    public class SessaoService:ISessaoInterface
    {

        private readonly IHttpContextAccessor _contextAccessor;

        public SessaoService (IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public UsuarioModel BuscarSessao()
        {
            var sessaoUsuario = _contextAccessor.HttpContext.Session.GetString("sessaoUsuario");
            if(string.IsNullOrEmpty(sessaoUsuario))
            {
                return null;
            }
            else { 
                return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
            }
        }

        public void RemoverSessao()
        {
            _contextAccessor.HttpContext.Session.Remove("sessaoUsuario");
        }

        public void CriarSessao (UsuarioModel usuario)
        {
            var usuarioJson = JsonConvert.SerializeObject(usuario);
            _contextAccessor.HttpContext.Session.SetString("sessaoUsuario", usuarioJson);
        }

    }
}
