using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escola.Migrations
{
    public partial class populaCursos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO Cursos(Nome, Area, Duracao)
            Values('TSI', 'Computação',6)");
            migrationBuilder.Sql(@"INSERT INTO Cursos(Nome, Area, Duracao)
            Values('TEC. Info', 'Computação',8)");
            migrationBuilder.Sql(@"INSERT INTO Cursos(Nome, Area, Duracao)
            Values('TEC. Ali', 'Alimentos',8)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Cursos;");
        }
    }
}
