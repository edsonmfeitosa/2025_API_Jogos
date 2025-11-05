using API_Aula.Model;
using Microsoft.AspNetCore.Mvc;

namespace API_Aula.Controllers
{
    public class AlunoController : ControllerBase
    {
        public static List<Aluno> alunos = new()
        {
            new Aluno { Ra = "123", Nome = "João Silva", Email = "joao@gmail.com" },
            new Aluno { Ra = "456", Nome = "Maria Souza", Email = "maria@gmail.com" }
        };
        [HttpGet]
        [Route("api/aluno")]
        public IActionResult GetAlunos()
        {
            return Ok(alunos);
        }
        [HttpGet]
        [Route("api/aluno/{ra}")]
        public IActionResult GetAlunoByRa(string ra)
        {
            var aluno = alunos.FirstOrDefault(a => a.Ra == ra);
            if (aluno == null)
            {
                return NotFound();
            }
            return Ok(aluno);
        }
        [HttpPost]
        [Route("api/aluno")]
        public IActionResult AddAluno([FromBody] Aluno novoAluno)
        {
            alunos.Add(novoAluno);
            return Ok(novoAluno);
        }
        [HttpPut]
        [Route("api/aluno/{ra}")]
        public IActionResult UpdateAluno(string ra, [FromBody] Aluno alunoAtualizado)
        {
            var aluno = alunos.FirstOrDefault(a => a.Ra == ra);
            if (aluno == null)
            {
                return NotFound();
            }
            aluno.Nome = alunoAtualizado.Nome;
            aluno.Email = alunoAtualizado.Email;
            return Ok(aluno);
        }
        [HttpDelete]
        [Route("api/aluno/{ra}")]
        public IActionResult DeleteAluno(string ra)
        {
            var aluno = alunos.FirstOrDefault(a => a.Ra == ra);
            if (aluno == null)
            {
                return NotFound();
            }
            alunos.Remove(aluno);
            return Ok();
        }
    }
}
