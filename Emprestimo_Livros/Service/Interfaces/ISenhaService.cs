using DocumentFormat.OpenXml.VariantTypes;
using System.Security.Cryptography;

namespace Emprestimo_Livros.Service.Interfaces
{
    public interface ISenhaService
    {
        void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt);
        
    }
}
