using Emprestimo_Livros.Data;
using Emprestimo_Livros.Models;
using Emprestimo_Livros.Repository;
using Emprestimo_Livros.Service;
using Microsoft.AspNetCore.Mvc;

namespace Emprestimo_Livros.Controllers
{
    [Route("EmprestimoLivros")]
    public class EmprestimoLivrosController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

        public EmprestimoRepository _emprestimoRepository;

        public EmprestimoService _emprestimoService { get; set; }


        public EmprestimoLivrosController(ApplicationDBContext dbContext, EmprestimoRepository emprestimoRepository, EmprestimoService emprestimoService)
        {
            _dbContext = dbContext;
            _emprestimoRepository = emprestimoRepository;
            _emprestimoService = emprestimoService;
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
                DataEmprestimoLivro = DateTime.Now,
                Status = "Emprestado"
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
            emprestimo.Status = "Emprestado";

            if (ModelState.IsValid)
            {
                _dbContext.EmprestimoLivros.Add(emprestimo);
                _dbContext.SaveChanges(); //passar para repository
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

        [HttpPost("Editar")]
        public IActionResult Editar(int id)
        {

            EmprestimoModel emprestimo = new EmprestimoModel();
            emprestimo = _emprestimoRepository.ListarPorId(id);

            return View("editar", emprestimo);
        }


        [HttpPost("ResultadoEdicao")]
        public IActionResult ResultadoEdicao(EmprestimoModel emprestimo)
        {


            if (_emprestimoRepository.Editar(emprestimo))
            {
                ViewBag.mensagem = "Item registrado com sucesso !";

                return View("~/Views/Home/Index.cshtml");

            }

            ViewBag.mensagem = "Item não pode ser registrado !";
            return Editar(emprestimo.Id);


        }

        [HttpPost("Excluir")]
        public IActionResult Deletar(int id)
        {
            if (_emprestimoRepository.Excluir(id))
            {
                TempData["mensagem"] = "Item deletado com sucesso !";
                
            }
            return RedirectToAction("Consultar");
        }


        [HttpPost("api/ConsultarRecebedor")]
        public IActionResult ConsultarPorRecebedor([FromBody] Dictionary<string, object> request)
        {
            string nomeRecebedor = request["nomeRecebedor"]?.ToString();

            (IEnumerable<EmprestimoModel> resultado, string mensagem ) = _emprestimoService.ConsultarRecebedor(nomeRecebedor);

            return Ok(new
            {
                success = new
                {
                    sucess = true,
                    data = new
                    {
                        resultado = resultado
                    },
                    mensagem = mensagem
                }
            });


            //criar a class para response json
        }


        [HttpPost("api/ConsultaFornecedor")]
        public IActionResult ConsultaPorFornecedor([FromBody] Dictionary<string, object> request)
        {
            string nomeFornecedor = request["nomeFornecedor"]?.ToString();

            (IEnumerable<EmprestimoModel> resultado, string mensagem) = _emprestimoService.ConsultarFornecedor(nomeFornecedor);

            return Ok(new
            {
                success = new
                {
                    sucess = true,
                    data = new
                    {
                        resultado = resultado
                    },
                    mensagem = mensagem
                }
            });


            //criar a class para response json
        }

    }


}
