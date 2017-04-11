using ProjetoViagens.DB.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Data.Base
{
    abstract class CrudAbstract<T> : Connection
    {
        public abstract T Incluir(T entidade, string procedure);
        public abstract List<T> Listar(string procedure);
        public abstract T Atualizar(T entidade, string procedure);
        public abstract T Obter(string nome, string procedure);
        public abstract void Excluir(int Id, string procedure);
    }
}
