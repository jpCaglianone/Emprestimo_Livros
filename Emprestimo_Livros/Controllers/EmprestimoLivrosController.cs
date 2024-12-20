using Emprestimo_Livros.Data;
using Emprestimo_Livros.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Emprestimo_Livros.Controllers
{
    [Route("EmprestimoLivros")]
    public class EmprestimoLivrosController : Controller
    {


        private readonly ApplicationDBContext _dbContext;

        public EmprestimoLivrosController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("Consultar")] //pode abstrair, mas to mantendo para deixar explicativo
        public IActionResult Consultar()
        {
            IEnumerable<EmprestimoModel> model = _dbContext.EmprestimoLivros; 
            return View("Consultar", model);
        }
        [HttpGet("Registrar")]
        public IActionResult Registrar() //se o nome da classe nao tiver de acordo com a asp-controller,
                                         //nao funciona, se o nome da classe for igual ao da view, nao precisa
                                         //colocar o nome da view, pode deixar return View() 
        {
            ViewData["Title"] = "Registrar novo empréstimo";
            DateTime data = DateTime.Now;
            ViewBag.data = data;
            return View("Registrar");
        }

        [HttpPost("Registrar")] //no form, o nome Registrar precisa estar no 
        public IActionResult ResultadoRegistrar(EmprestimoModel emprestimo) 
        {
            bool sucesso = false;
            ViewBag.sucesso = sucesso;
            if (!sucesso)
            {
                ViewBag.mensagem = "Não foi possivel realizar o registro!";
            }
            else
            {
                ViewBag.mensagem = "Registro realizado com sucesso!";
            }
                
            return View("Registrar");
        }
    }
}
