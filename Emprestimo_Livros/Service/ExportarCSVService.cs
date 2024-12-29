using System.Collections.Generic;
using System.Text;

namespace Emprestimo_Livros.Service
{
    public class ExportarCSVService
    {

        public bool GerarCSV(dynamic dados)
        {
                       
            string nomeArquivo = "Relatorio_" + "teste.csv";

            File.WriteAllText(nomeArquivo, dados.ToString());

            return true;
        }

    }
}
