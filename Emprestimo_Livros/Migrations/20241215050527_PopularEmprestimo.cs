using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emprestimo_Livros.Migrations
{
    /// <inheritdoc />
    public partial class PopularEmprestimo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFilePath = Path.Combine("Scripts", "PopularEmprestimoLivros.sql");
            var sqlScript = File.ReadAllText(sqlFilePath);

            
            migrationBuilder.Sql(sqlScript);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
