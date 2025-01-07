using ClosedXML.Excel;
using Emprestimo_Livros.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Emprestimo_Livros.Service
{
    public class ExportarCSVService : ControllerBase
    {
        private readonly EmprestimoRepository _emprestimoRepository;

        public ExportarCSVService(EmprestimoRepository emprestimoRepository)
        {
            _emprestimoRepository = emprestimoRepository;
        }

        public IActionResult GerarCSV(string dados)
        {
            try
            {
                if (string.IsNullOrEmpty(dados))
                    return BadRequest();

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "relatorios");
                Directory.CreateDirectory(path);

                string nomeArquivo = "Relatorio_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
                string caminhoCompleto = Path.Combine(path, nomeArquivo);

                System.IO.File.WriteAllText(caminhoCompleto, dados);
                return Ok(caminhoCompleto);
            }
            catch
            {
                return BadRequest();
            }
        }

        public DataTable GerarExcel()
        {
            var dados = _emprestimoRepository.ListarTodos().ToList();
            DataTable dt = new DataTable();
            dt.TableName = "Relatorio elaborado";
            dt.Columns.Add("Recebedor", typeof(string));
            dt.Columns.Add("Fornecedor", typeof(string));
            dt.Columns.Add("Livro", typeof(string));
            dt.Columns.Add("Data Empréstimo", typeof(DateTime));
            dt.Columns.Add("Status", typeof(string));

            foreach (var item in dados)
            {
                dt.Rows.Add(
                    item.RecebedorNome,
                    item.FornecedorNome,
                    item.LivroEmprestadoNome,
                    item.DataEmprestimoLivro,
                    item.Status
                );
            }
            return dt;
        }

        public byte[] ExportarExcel()
        {
            var dados = GerarExcel();
            using (var wb = new XLWorkbook())
            {
                wb.AddWorksheet(dados, "Emprestimos");
                using (var ms = new MemoryStream())
                {
                    wb.SaveAs(ms);
                    return ms.ToArray();
                }
            }
        }
    }
}