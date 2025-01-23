
using Emprestimo_Livros.DTO;
using Emprestimo_Livros.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Usuario.DTO;

namespace Usuario.Controllers
{
    [Route("Usuario")]
    public class UsuarioController : Controller
    {

        private readonly IUsuarioRegistroService _registroService;
        private readonly ISessaoInterface _sessaoInterface;

        public UsuarioController (IUsuarioRegistroService registroService, ISessaoInterface sessaoInterface)
        {
            _registroService = registroService;
            _sessaoInterface = sessaoInterface;
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



        [HttpGet("/Login")]
        public IActionResult LoginGet(UsuarioRegistroDTO registroDTO)
        {

            return View("Login");
        }

        [HttpPost("/Login")]
        public IActionResult LoginPost(LoginDTO dto)
        {

            if (ModelState.IsValid)
            {
                var usuario = _registroService.LoginUsuario(dto);
                if (usuario.Status) {
                    TempData["Mensagem"] =usuario.Mensagem;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Mensagem"] = usuario.Mensagem;
                    return RedirectToAction("Index", dto);

                }
            }
            else
            {
                return RedirectToAction("Index");   
            }

            return View("Login");

        }

    }
}
