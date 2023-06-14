using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escola.Migrations
{
    public partial class populaAlunos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO Alunos(Nome, DataNascimento, Cpf, CursoId)
            Values('Joao','2011-05-28','765.432.123-09', 1)");
            migrationBuilder.Sql(@"INSERT INTO Alunos(Nome, DataNascimento, Cpf, CursoId)
            Values('Maria','2011-05-28','765.432.123-08', 2)");
            migrationBuilder.Sql(@"INSERT INTO Alunos(Nome, DataNascimento, Cpf, CursoId)
            Values('Maria','2012-04-28','765.432.123-01', 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Alunos;");
        }
    }
}
