using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.DB.Base
{
    public class Connection
    {
        public SqlConnection GetConnection()
        {
            string ConnString = ConfigurationManager.ConnectionStrings["ViagensInterplanetariasDB"].ConnectionString;
            SqlConnection Conn = new SqlConnection(ConnString);
            
            return Conn;          
        }

        public SqlCommand GetSqlCommand(string procedure)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = procedure;
            comando.Connection = GetConnection();
            comando.Connection.Open();
            
            return comando;
        }

    }
}
