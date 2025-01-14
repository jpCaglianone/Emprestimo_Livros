
using Emprestimo_Livros.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Usuario.DTO;

namespace Usuario.Controllers
{
    [Route("Usuario")]
    public class UsuarioController : Controller
    {

        private readonly IUsuarioRegistroService _registroService;

        public UsuarioController (IUsuarioRegistroService registroService)
        {
            _registroService = registroService;
        }   

        [HttpGet("/Registrar")]
        public IActionResult RegistrarGet(UsuarioRegistroDTO registroDTO)
        {

            return View("Registrar");
        }

        [HttpPost("/Registrar")]
        public IActionResult RegistrarPost(UsuarioRegistroDTO registroDTO)
        {

            if (ModelState.IsValid)
            {
                var usuario =  _registroService.RegistrarUsuario(registroDTO);
                
                if (usuario.Status)
                {
                    TempData["MensagemSucesso"] = usuario.Mensagem;
                }
                else
                {
                    TempData["MensagemErro"] = usuario.Mensagem;
                    return View("Registrar",registroDTO);
                }
                return RedirectToAction("Index");
            
            }
            else
            {
                return View("Registrar",registroDTO);
            }
           
        }
    }
}
