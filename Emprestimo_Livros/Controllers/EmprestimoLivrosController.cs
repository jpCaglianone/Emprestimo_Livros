using Emprestimo_Livros.Data;
using Emprestimo_Livros.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emprestimo_Livros.Controllers
{
    public class EmprestimoLivrosController : Controller
    {

        private readonly ApplicationDBContext _dbContext;

        public EmprestimoLivrosController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult ListarEmprestimoLivros()
        {
            IEnumerable<EmprestimoModel> model = _dbContext.EmprestimoLivros; 
            return View("ListarEmprestimos", model);
        }

        public IActionResult RegistrarEmprestimoLivro()
        {
            return View("RegistrarEmprestimos");
        }
    }
}
