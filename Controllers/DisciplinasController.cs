using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Escola.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Escola.Model;
using Microsoft.EntityFrameworkCore;

namespace Escola.Controllers
{
    [Route("[controller]")]
    public class DisciplinasController : Controller
    {
        private readonly ILogger<DisciplinasController> _logger;
         private readonly EscolaDbContext _context;

        public DisciplinasController(ILogger<DisciplinasController> logger, EscolaDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Disciplina>> Get()
        {
            var disciplinas = _context.Disciplinas.ToList();
            if(disciplinas == null)
            {
                return NotFound();
            }
            return disciplinas;
        }

        [HttpGet("{id:int}")]
        public ActionResult<Disciplina> Get(int id)
        {
            var disciplinas = _context.Disciplinas.FirstOrDefault(p => p.Id == id);
            if(disciplinas == null)
                return NotFound("Disciplina não encontrado.");
            
            return disciplinas;
        }

         [HttpPost]
        public ActionResult Post(Disciplina disciplina)
        {
            _context.Disciplinas.Add(disciplina);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetDisciplina", 
            new {
                id = disciplina.Id,
                disciplina
            });
        }
        
        [HttpPut("{id:int}")]
        public ActionResult Put (int id, Disciplina disciplina)
        {
            if(id != disciplina.Id)
            {
                return BadRequest();
            }

            _context.Entry(disciplina).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(disciplina);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete (int id)
        {
            var disciplinas = _context.Disciplinas.FirstOrDefault(p => p.Id == id);
            if(disciplinas is null)
                return NotFound("Curso não encontrado.");
            
            _context.Disciplinas.Remove(disciplinas);
            _context.SaveChanges();

            return Ok(disciplinas);
        }
    }
}