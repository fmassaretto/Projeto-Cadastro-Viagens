using ProjetoViagens.DB.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Data.Interfaces
{
    public interface ICrud
    {
        SqlDataReader ExecuteProc(string query, List<SqlParameter> parametros);
    }
}
