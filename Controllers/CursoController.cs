using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Escola.Model;

namespace Escola.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CursoController : Controller
    {
        private readonly ILogger<CursoController> _logger;

        public CursoController(ILogger<CursoController> logger)
        {
            _logger = logger;
        }
         
        [HttpGet(Name = "cursos")]
        public List<Curso> GetCursos()
        {
            List<Curso> cursos = new List<Curso>();
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

            cursos.Add(new Curso{
                Nome = "Programação para Internet",
                Area = "149",
                Duracao = 6,
                disciplinas = disciplinas
            });

            cursos.Add(new Curso{
                Nome = "POO",
                Area = "240",
                Duracao = 3,
                disciplinas = disciplinas 
            });

            cursos.Add(new Curso{
                Nome = "Back-end",
                Area = "130",
                Duracao = 4,
                disciplinas = disciplinas
            });

            cursos.Add(new Curso{
                Nome = "Front-end",
                Area = "130",
                Duracao = 2,
                disciplinas = disciplinas
            });

            return cursos;    
        }}
   
    }
