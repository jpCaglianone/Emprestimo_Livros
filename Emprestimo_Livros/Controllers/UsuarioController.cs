using Emprestimo_Livros.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Usuario.Controllers
{
    [Route("Usuario")]
    public class UsuarioController : Controller
    {

        [HttpGet("/Registrar")]
        public IActionResult RegistrarGet(UsuarioRegistroDTO registroDTO)
        {

            return View("Registrar");
        }

        [HttpPost("/Registrar")]
        public IActionResult RegistrarPost(UsuarioRegistroDTO registroDTO)
        {
            return View("Registrar");
        }
    }
}
