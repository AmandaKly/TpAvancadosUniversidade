using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.Model
{
    public class Aluno
    {
        public int Id {get;set;}
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }

        public List<Curso> cursos {get; set;}
        public List<Disciplina> disciplinas {get; set;}
        public Aluno(){
            cursos = new List<Curso>();
            disciplinas = new List<Disciplina>();
        }
    }
}