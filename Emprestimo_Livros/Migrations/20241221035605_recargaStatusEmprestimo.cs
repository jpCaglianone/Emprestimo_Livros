using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emprestimo_Livros.Migrations
{
    /// <inheritdoc />
    public partial class recargaStatusEmprestimo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFilePath = Path.Combine("Scripts", "RecargaStatusEmprestimo.sql");
            var sqlScript = File.ReadAllText(sqlFilePath);


            migrationBuilder.Sql(sqlScript); 

            migrationBuilder.Sql(sqlScript);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
