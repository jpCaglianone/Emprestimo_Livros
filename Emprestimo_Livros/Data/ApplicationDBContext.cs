using Emprestimo_Livros.Models;
using Microsoft.EntityFrameworkCore;

namespace Emprestimo_Livros.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
    
        public DbSet<EmprestimoModel> EmprestimoLivros { get; set; }

    
    }
}
