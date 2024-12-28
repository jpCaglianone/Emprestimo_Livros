using Emprestimo_Livros.Models;
using Emprestimo_Livros.Repository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Emprestimo_Livros.Service
{
    public class EmprestimoService
    {

        private readonly IServiceCollection _services;
        private readonly IConfiguration _config;
        private readonly EmprestimoRepository _repository;

        public EmprestimoService (EmprestimoRepository emprestimoRepository)
        {
           _repository = emprestimoRepository;
        }

        public (IEnumerable<EmprestimoModel> resultado, string mensagem) ConsultarRecebedor (string nome)
        {

          (bool sucesso, string mensagem) = validacaoNome (nome);
            if (!sucesso) {
                return (Enumerable.Empty<EmprestimoModel>(), mensagem);
            }

          return  (_repository.ConsultarRecebedor (nome), mensagem);
        }

        public (IEnumerable<EmprestimoModel> resultado, string mensagem) ConsultarFornecedor(string nome)
        {

            (bool sucesso, string mensagem) = validacaoNome(nome);
            if (!sucesso)
            {
                return (Enumerable.Empty<EmprestimoModel>(), mensagem);
            }

            return (_repository.ConsultarFornecedor(nome), mensagem);
        }

        public (bool validade, string erro) validacaoNome(string nome)
        {
            if (string.IsNullOrEmpty(nome) || !nome.All(n => char.IsLetter(n)) )
            {
                return (false, "Padrão de nome incorreto, é permitido apenas letras e campo nao pode estar vazio!");
            }

            return (true, "sucesso");
        }
       
    }
}
