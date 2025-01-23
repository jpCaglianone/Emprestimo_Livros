using Emprestimo_Livros.Models;

namespace Emprestimo_Livros.Service.Interfaces
{
    public interface ISessaoInterface
    {
        void CriarSessao(UsuarioModel usuario);
        void RemoverSessao();
        UsuarioModel BuscarSessao();
    }
}
