using Emprestimo_Livros.Data;
using Emprestimo_Livros.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("Consultar")]
        public IActionResult Consultar()
        {
            IEnumerable<EmprestimoModel> model = _dbContext.EmprestimoLivros;
            return View("Consultar", model);
        }

        [HttpGet("Registrar")]
        public IActionResult Registrar()
        {
            ViewBag.sucesso = null;
            var model = new EmprestimoModel
            {
                DataEmprestimoLivro = DateTime.Now 
            };
            return View("Registrar", model);
        }

        [HttpGet("api/Consultar")]
        public IEnumerable<EmprestimoModel> ApiConsultar()
        {
            IEnumerable<EmprestimoModel> lista = _dbContext.EmprestimoLivros.ToList();
            return lista;
        }

        [HttpPost("Registrar")]
        public IActionResult ResultadoRegistrar(EmprestimoModel emprestimo)
        {
            emprestimo.DataEmprestimoLivro = DateTime.Now;

            if (ModelState.IsValid)
            {
                _dbContext.EmprestimoLivros.Add(emprestimo);
                _dbContext.SaveChanges();
                ViewBag.sucesso = true;
                ViewBag.mensagem = "Registro realizado com sucesso!";
            }
            else
            {
                ViewBag.sucesso = false;
                ViewBag.mensagem = "Não foi possível realizar o registro!";
            }

            return View("Registrar", emprestimo);
        }
    }
}
