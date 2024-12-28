using Emprestimo_Livros.Data;
using Emprestimo_Livros.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Emprestimo_Livros.Repository
{
    public class EmprestimoRepository
    {

        private readonly ApplicationDBContext _db;

        public EmprestimoRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public Boolean Editar (EmprestimoModel emprestimo)
        {
                        
            try
            {
                _db.Update(emprestimo);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //criar o arquivo de log
                Console.WriteLine(ex.Message);
              
            }

            return false;
        }

        public IEnumerable<EmprestimoModel> ListarTodos()
        {
            return _db.EmprestimoLivros;
        }

        public EmprestimoModel ListarPorId(int id)
            {
            return _db.EmprestimoLivros.FirstOrDefault(e => e.Id == id);
            //return NotFound()
        }

        public Boolean Excluir(int id)
        {
            EmprestimoModel emprestimo = ListarPorId(id);

            try
            {
                _db.EmprestimoLivros.Remove(emprestimo);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e) { 
                Console.WriteLine(e.Message);
            }

            return false;
        }


        public IEnumerable<EmprestimoModel> ConsultarRecebedor(string nome)
        {
            var sqlFilePath = Path.Combine("Scripts", "ConsultaRecebedor.sql");
            var sqlScript = File.ReadAllText(sqlFilePath);

            var nomeSql = new SqlParameter("@Nome", "%" + nome + "%");

            return _db.EmprestimoLivros.FromSqlRaw(sqlScript, nomeSql);
            // entender o SqlParameter
            // tratar resultado
            

        }
        public IEnumerable<EmprestimoModel> ConsultarFornecedor(string nome)
        {
            var sqlFilePath = Path.Combine("Scripts", "ConsultaFornecedor.sql");
            var sqlScript = File.ReadAllText(sqlFilePath);

            var nomeSql = new SqlParameter("@Nome", "%" + nome + "%");

            return _db.EmprestimoLivros.FromSqlRaw(sqlScript, nomeSql);
            // entender o SqlParameter
            // tratar resultado


        }
    }
}
