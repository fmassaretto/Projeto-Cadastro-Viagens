using ProjetoViagens.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProjetoViagens.DB.Base;

namespace ProjetoViagens.Data
{
    class Repository<T> : Connection, ICrud
    {
        public SqlDataReader ExecuteProc(string query, List<SqlParameter> parametros)
        {
            SqlCommand comando = new SqlCommand();
            Connection conexao = new Connection();
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = query;

            foreach (var item in parametros)
            {
                comando.Parameters.Add(item);
            }
            comando.Connection = conexao.GetConnection();
            comando.Connection.Open();
            SqlDataReader reader = comando.ExecuteReader();

            return reader;
        }

        public SqlDataReader ExecuteProc(string query)
        {
            SqlCommand comando = new SqlCommand();
            Connection conexao = new Connection();
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = query;

            comando.Connection = conexao.GetConnection();
            comando.Connection.Open();
            SqlDataReader reader = comando.ExecuteReader();

            return reader;
        }

    }
}
