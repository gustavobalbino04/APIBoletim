using APIBoletim.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBoletim.Interfaces
{
    interface IAluno
    {
        List<Aluno> ListarTodos();
        Aluno BuscarporID(int Id);
        Aluno Alterar(Aluno a);
        Aluno Excluir(Aluno a);
        Aluno Cadastrar(Aluno a);
    }
}
