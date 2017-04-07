using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.DB.Base
{
    class Connection
    {
        public Connection()
        {
            string Conn = ConfigurationManager.ConnectionStrings["ViagensInterplanetariasDB"].ConnectionString;
            using (SqlConnection DBConn = new SqlConnection(Conn))
            {
                DBConn.Open();
            }
        }
        public SqlCommand Comando(string query) {
            return null;

        }


    }
}
