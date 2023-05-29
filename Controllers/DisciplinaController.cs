using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Escola.Model;

namespace Escola.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisciplinaController : ControllerBase
    {
        private readonly ILogger<Curso> _logger;
        public DisciplinaController(ILogger<Curso> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "disciplinas")]
        public List<Disciplina> GetDisciplina()
        {
            List<Disciplina> disciplinas = new List<Disciplina>();

            disciplinas.Add(new Disciplina{
                Nome = "Programação para Internet",
                CargaHoraria = 60,
                Semestre = 6
            });

            disciplinas.Add(new Disciplina{
                Nome = "POO",
                CargaHoraria = 240,
                Semestre = 3 
            });

            disciplinas.Add(new Disciplina{
                Nome = "Back-end",
                CargaHoraria = 130,
                Semestre = 4
            });

            disciplinas.Add(new Disciplina{
                Nome = "Front-end",
                CargaHoraria = 130,
                Semestre = 2
            });
            return disciplinas;    
        }
    }
}