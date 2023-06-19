using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Escola.data;
using Escola.Model;
using Microsoft.EntityFrameworkCore;

namespace Escola.Controllers
{
    [Route("[controller]")]
    public class AlunosController : Controller
    {
        private readonly ILogger<AlunosController> _logger;
        private readonly EscolaDbContext _context;

        public AlunosController(ILogger<AlunosController> logger, EscolaDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Aluno>> Get()
        {
            var alunos = _context.Alunos.ToList();
            if(alunos == null)
            {
                return NotFound();
            }
            return alunos;
        }

        [HttpGet("{id:int}")]
        public ActionResult<Aluno> Get(int id)
        {
            var alunos = _context.Alunos.FirstOrDefault(p => p.Id == id);
            if(alunos == null)
                return NotFound("Aluno não encontrado.");
            
            return alunos;
        }

         [HttpPost]
        public ActionResult Post(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetAluno", 
            new {
                id = aluno.Id,
                aluno
            });
        }

        [HttpPut("{id:int}")]
        public ActionResult Put (int id, Aluno aluno)
        {
            if(id != aluno.Id)
            {
                return BadRequest();
            }

            _context.Entry(aluno).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(aluno);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete (int id)
        {
            var alunos = _context.Alunos.FirstOrDefault(p => p.Id == id);
            if(alunos is null)
                return NotFound("Aluno não encontrado.");
            
            _context.Alunos.Remove(alunos);
            _context.SaveChanges();

            return Ok(alunos);
        }
    }
}