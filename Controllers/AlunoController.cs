using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIBoletim.Domains;
using APIBoletim.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBoletim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        AlunoRepository repositorio = new AlunoRepository();
        // GET: api/<AlunoController>
        [HttpGet]
        public List<Aluno> Get()
        {
            return repositorio.ListarTodos();
        }

        // GET: api/Aluno/5
        [HttpGet("{id}")]
        public Aluno Get(int id)
        {
            return repositorio.BuscarporID(id);
        }

        // POST: api/Aluno
        [HttpPost]
        public Aluno Post([FromBody] Aluno a)
        {
            return repositorio.Cadastrar(a);
        }

        // PUT: api/Aluno/5
        [HttpPut("{id}")]
        public Aluno Put(int id, [FromBody] Aluno a )
        {
            return repositorio.Alterar(id, a);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repositorio.Excluir(id);
        }
    }
}
