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
    public class CursosController : Controller
    {
        private readonly ILogger<CursosController> _logger;
         private readonly EscolaDbContext _context;

        public CursosController(ILogger<CursosController> logger, EscolaDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Curso>> Get()
        {
            var cursos = _context.Cursos.ToList();
            if(cursos == null)
            {
                return NotFound();
            }
            return cursos;
        }

        [HttpGet("{id:int}")]
        public ActionResult<Curso> Get(int id)
        {
            var cursos = _context.Cursos.FirstOrDefault(p => p.Id == id);
            if(cursos == null)
                return NotFound("Curso não encontrado.");
            
            return cursos;
        }

        [HttpPost]
        public ActionResult Post(Curso curso)
        {
            _context.Cursos.Add(curso);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetCurso", 
            new {
                id = curso.Id,
                curso
            });
        }

        [HttpPut("{id:int}")]
        public ActionResult Put (int id, Curso curso)
        {
            if(id != curso.Id)
            {
                return BadRequest();
            }

            _context.Entry(curso).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(curso);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete (int id)
        {
            var cursos = _context.Cursos.FirstOrDefault(p => p.Id == id);
            if(cursos is null)
                return NotFound("Curso não encontrado.");
            
            _context.Cursos.Remove(cursos);
            _context.SaveChanges();

            return Ok(cursos);
        }
    }
}