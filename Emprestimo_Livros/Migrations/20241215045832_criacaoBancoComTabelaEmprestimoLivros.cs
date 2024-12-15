using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emprestimo_Livros.Migrations
{
    /// <inheritdoc />
    public partial class criacaoBancoComTabelaEmprestimoLivros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmprestimoLivros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecebedorNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FornecedorNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LivroEmprestadoNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEmprestimoLivro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmprestimoLivros", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmprestimoLivros");
        }
    }
}
