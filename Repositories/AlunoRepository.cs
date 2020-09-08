using APIBoletim.Context;
using APIBoletim.Domains;
using APIBoletim.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIBoletim.Repositories
{
    public class AlunoRepository : IAluno
    {
        //Contexto chamado 
        BoletimContext conexao = new BoletimContext();
        //Chamamos a classe que permite colocar consultas de banco de dados 
        SqlCommand cmd = new SqlCommand();
        public Aluno Alterar(int id, Aluno a )
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE Aluno SET " +
                "Nome = @nome, " +
                "RA = @ra, " +
                "Idade = @idade WHERE IaAluno = @id";

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nome", a.Nome);
            cmd.Parameters.AddWithValue("@ra", a.RA);
            cmd.Parameters.AddWithValue("@idade", a.Idade);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return a;
        }

        public Aluno BuscarporID(int Id)
        {
            cmd.Connection = conexao.Conectar();
            //abribuimos nossa conexão 
            cmd.CommandText = "SELECT * FROM Aluno WHERE IdAluno = @id";
            //Nomeando que e o @id
            cmd.Parameters.AddWithValue("@id", Id);

            SqlDataReader dados = cmd.ExecuteReader();

            Aluno a = new Aluno();

            while (dados.Read())
            {
                a.IdAluno = Convert.ToInt32(dados.GetValue(0));
                a.Nome = dados.GetValue(1).ToString();
                a.RA = dados.GetValue(2).ToString();
                a.Idade = Convert.ToInt32(dados.GetValue(3));
            }
           
            conexao.Desconectar();

            return a;
            
        }

        public Aluno Cadastrar(Aluno a)
        {
            
           cmd.Connection = conexao.Conectar();

            cmd.CommandText = "INSERT INTO Aluno" +
                "(Nome, Ra,Idade)"+
                "VALUES"+
                "(@nome, @ra, @idade)";
            cmd.Parameters.AddWithValue("@nome", a.Nome);
            cmd.Parameters.AddWithValue("@ra", a.RA);
            cmd.Parameters.AddWithValue("@idade", a.Idade);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return a;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM Aluno WHERE IdAluno = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            conexao.Desconectar();
          
        }

        public List<Aluno> ListarTodos()
        {
            //Abrimos a conexao
            cmd.Connection = conexao.Conectar();
            //abribuimos nossa conexão 
            cmd.CommandText = "SELECT * FROM Aluno";
            //ler os dados 
            SqlDataReader dados = cmd.ExecuteReader();

            List<Aluno> alunos = new List<Aluno>();

            while (dados.Read())
            {
                alunos.Add(
                    new Aluno()
                    {
                        IdAluno = Convert.ToInt32(dados.GetValue(0)),
                        Nome = dados.GetValue(1).ToString(),
                        RA = dados.GetValue(2).ToString(),
                        Idade = Int32.Parse(dados.GetValue(3).ToString()),
                    }
                );
            }

            //Fechamos a conexao
            conexao.Desconectar();
            return alunos;
        }
    }
}
