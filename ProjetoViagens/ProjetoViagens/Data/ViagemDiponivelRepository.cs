using ProjetoViagens.Data.Base;
using ProjetoViagens.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Data
{
    class ViagemDiponivelRepository : CrudAbstract<ViagensDispo>
    {
        public override ViagensDispo Atualizar(ViagensDispo entidade, string procedure)
        {
            SqlCommand comando = GetSqlCommand(procedure);
            comando.Parameters.AddWithValue("@Id",entidade.Id);
            comando.Parameters.AddWithValue("@PlanetaOrigem", entidade.PlanetaOrigem);
            comando.Parameters.AddWithValue("@PlanetaDestino", entidade.PlanetaDestino);
            comando.Parameters.AddWithValue("@Valor", entidade.Valor);
            comando.Parameters.AddWithValue("@Tempo", entidade.Tempo);

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

        public override void Excluir(int Id, string procedure)
        {
            SqlCommand comando = GetSqlCommand(procedure);
            comando.Parameters.AddWithValue("@Id", Id);

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

        public override ViagensDispo Incluir(ViagensDispo entidade, string procedure)
        {
            SqlCommand comando = GetSqlCommand(procedure);

            comando.Parameters.AddWithValue("@PlanetaOrigem", entidade.PlanetaOrigem);
            comando.Parameters.AddWithValue("@PlanetaDestino", entidade.PlanetaDestino);
            comando.Parameters.AddWithValue("@Valor", entidade.Valor);
            comando.Parameters.AddWithValue("@Tempo", entidade.Tempo);

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

        public override List<ViagensDispo> Listar(string procedure)
        {
            SqlCommand comando = GetSqlCommand(procedure);

            List<ViagensDispo> listaViagens = new List<ViagensDispo>();

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                listaViagens.Add(new ViagensDispo(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetInt32(3),
                reader.GetInt32(4)
                ));
            }

            return listaViagens;
        }

        public override ViagensDispo Obter(string nome, string procedure)
        {
            throw new NotImplementedException();
        }

        public List<ViagensDispo> ObterViagens(string nome, string procedure)
        {
            SqlCommand comando = GetSqlCommand(procedure);

            List<ViagensDispo> listaViagens = new List<ViagensDispo>();

            comando.Parameters.AddWithValue("@Nome", nome);
            SqlDataReader reader = comando.ExecuteReader();

            ViagensDispo viagem = new ViagensDispo();
            while (reader.Read())
            {
                listaViagens.Add(new ViagensDispo(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetInt32(3),
                reader.GetInt32(4)
                ));
            }

            return listaViagens;
        }
    }
}
