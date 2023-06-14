using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escola.Migrations
{
    public partial class populaDisciplinas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO Disciplinas(Nome, CargaHoraria, Semestre, CursoId)
            Values('TP avançados',180,5,1)");
            migrationBuilder.Sql(@"INSERT INTO Disciplinas(Nome, CargaHoraria, Semestre, CursoId)
            Values('Testes',180,3,1)");
            migrationBuilder.Sql(@"INSERT INTO Disciplinas(Nome, CargaHoraria, Semestre, CursoId)
            Values('Mobile',180,1,1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Disciplinas;");
        }
    }
}
