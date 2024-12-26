using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emprestimo_Livros.Migrations
{
    /// <inheritdoc />
    public partial class inclusaoStatusEmprestimo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "EmprestimoLivros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "EmprestimoLivros");
        }
    }
}
