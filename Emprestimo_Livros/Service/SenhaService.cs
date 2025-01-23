using Emprestimo_Livros.Service.Interfaces;
using System.Security.Cryptography;

namespace Emprestimo_Livros.Service
{
    public class SenhaService : ISenhaService
    {
       
        public void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                senhaSalt = hmac.Key;
                senhaHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
            }
        }

        public bool VerificaSenha (string senha, byte[] senhaSalt, byte[] senhaHash)
        {
            using (var hmac = new HMACSHA512(senhaSalt))
            {
                var computerHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha)); 
                return computerHash.SequenceEqual(senhaHash);
            }
         }
    }
}
