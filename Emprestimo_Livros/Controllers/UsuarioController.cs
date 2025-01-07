
using Microsoft.AspNetCore.Mvc;
using Usuario.DTO;

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

            var a = registroDTO.Email;

            return View("Registrar");
        }
    }
}
