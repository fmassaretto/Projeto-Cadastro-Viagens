using ProjetoViagens.Data.Base;
using ProjetoViagens.DB.Base;
using ProjetoViagens.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Data
{
    class PlanetaRepository : CrudAbstract<Planetas>
    {
        public override Planetas Atualizar(Planetas entidade, string procedure)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = procedure;

            comando.Connection = base.GetConnection();
            comando.Connection.Open();

            comando.Parameters.AddWithValue("@Id", entidade.Id);
            comando.Parameters.AddWithValue("@Nome", entidade.Nome);
            comando.Parameters.AddWithValue("@Descricao", entidade.Descricao);
            comando.Parameters.AddWithValue("@PossuiOxigenio", entidade.PossuiOxigenio);

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("");
                Console.WriteLine("********************************");
                Console.WriteLine(reader["msgSucesso"]);
                Console.WriteLine("********************************");
                Console.WriteLine("");
            }

            return entidade;
        }

        public override void Excluir(int id, string procedure)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = procedure;

            comando.Connection = base.GetConnection();
            comando.Connection.Open();

            comando.Parameters.AddWithValue("@Id", id);

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("");
                Console.WriteLine("********************************");
                Console.WriteLine(reader["msgSucesso"]);
                Console.WriteLine("********************************");
                Console.WriteLine("");
            }
        }

        public override Planetas Incluir(Planetas entidade, string procedure)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = procedure;

            comando.Connection = base.GetConnection();
            comando.Connection.Open();

            comando.Parameters.AddWithValue("@Nome", entidade.Nome);
            comando.Parameters.AddWithValue("@Descricao", entidade.Descricao);
            comando.Parameters.AddWithValue("@PossuiOxigenio", entidade.PossuiOxigenio);

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("");
                Console.WriteLine("********************************");
                Console.WriteLine(reader["msgSucesso"]);
                Console.WriteLine("********************************");
                Console.WriteLine("");
            }

            return entidade;
        }

        public override List<Planetas> Listar(string procedure)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = procedure;

            List<Planetas> listaPlanetas = new List<Planetas>();

            comando.Connection = base.GetConnection();
            comando.Connection.Open();
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                listaPlanetas.Add(new Planetas(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetBoolean(3)
                ));
            }

            return listaPlanetas;
        }

        public override Planetas Obter(string nome, string procedure)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = procedure;

            comando.Connection = base.GetConnection();
            comando.Connection.Open();

            comando.Parameters.AddWithValue("@Nome", nome);
            SqlDataReader reader = comando.ExecuteReader();

            Planetas planeta = new Planetas();
            while (reader.Read())
            {
                planeta.Id = reader.GetInt32(0);
                planeta.Nome = reader.GetString(1);
                planeta.Descricao = reader.GetString(2);
                planeta.PossuiOxigenio = reader.GetBoolean(3);
            }

            return planeta;
        }
    }
}
