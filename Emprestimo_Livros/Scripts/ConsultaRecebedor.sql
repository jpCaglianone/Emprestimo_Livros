﻿SELECT             [Id],
                  [RecebedorNome],
                  [FornecedorNome],
                  [LivroEmprestadoNome],
                  [DataEmprestimoLivro],
                  [Status]
FROM [EmprestimoLivros].[dbo].[EmprestimoLivros]
WHERE RecebedorNome LIKE @Nome;
 