using Emprestimo_Livros.Data;
using Emprestimo_Livros.Models;

namespace Emprestimo_Livros.Repository
{
    public class UsuarioRepository
    {

        private readonly ApplicationDBContext _dbContext;
        public UsuarioRepository(ApplicationDBContext db)
        {
            _dbContext = db;
        }

        public bool RegistrarUsuario(UsuarioModel usuario)
        {
            try
            {
                _dbContext.Add(usuario);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
