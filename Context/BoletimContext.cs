using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIBoletim.Context
{
    public class BoletimContext
    {

        SqlConnection con = new SqlConnection();

        public BoletimContext()
        {
            con.ConnectionString = @"Data Source=LAB105201\SQLEXPRESS2;Initial Catalog=boletimg;User ID=sa;Password=sa132";

        }
        // meto para conectar ao banco de dados 
        public SqlConnection Conectar()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        // meto para desconectar o banco de dados 
        public void Desconectar()
        {
            if(con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }

    }
}
