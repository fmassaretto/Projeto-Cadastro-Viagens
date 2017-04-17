using ProjetoViagens.Data.Base;
using ProjetoViagens.Model.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Data
{
    class BookingRepository : CrudAbstract<ViagemCliente>
    {
        public override ViagemCliente Atualizar(ViagemCliente entidade, string procedure)
        {
            SqlCommand comando = GetSqlCommand(procedure);

            comando.Parameters.AddWithValue("@Id", entidade.CodigoReserva);
            comando.Parameters.AddWithValue("@IdViagemDispo", entidade.IdViagemDispo);
            comando.Parameters.AddWithValue("@IdCliente", entidade.IdCliente);
            comando.Parameters.AddWithValue("@IdTransporte", entidade.IdTransporte);

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
            throw new NotImplementedException();
        }

        public override ViagemCliente Incluir(ViagemCliente entidade, string procedure)
        {

            SqlCommand comando = GetSqlCommand(procedure);

            comando.Parameters.AddWithValue("@IdViagemDispo", entidade.IdViagemDispo);
            comando.Parameters.AddWithValue("@IdCliente", entidade.IdCliente);
            comando.Parameters.AddWithValue("@IdTransporte", entidade.IdTransporte);

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                entidade.clientes.Id = Convert.ToInt32(reader["Id"]);
                entidade.clientes.Nome = Convert.ToString(reader["NomeCliente"]);
                entidade.clientes.Documento = Convert.ToString(reader["Documento"]);
                entidade.clientes.Respira = Convert.ToBoolean(reader["Respira"]);
                entidade.CodigoReserva = Convert.ToInt32(reader["CodigoReserva"]);
                entidade.viagemDispo.PlanetaOrigem = Convert.ToString(reader["PlanetaOrigem"]);
                entidade.viagemDispo.PlanetaDestino = Convert.ToString(reader["PlanetaDestino"]);
                entidade.viagemDispo.Valor = Convert.ToInt32(reader["Valor"]);
                entidade.viagemDispo.Tempo= Convert.ToInt32(reader["Tempo"]);
                entidade.transportes.Nome = Convert.ToString(reader["NomeTransporte"]);
                entidade.transportes.Terreno = Convert.ToString(reader["Terreno"]);
                Console.WriteLine("");
                Console.WriteLine("********************************");
                Console.WriteLine(reader["msgSucesso"]);
                Console.WriteLine("********************************");
                Console.WriteLine("");
            }
            return entidade;
        }

        public override List<ViagemCliente> Listar(string procedure)
        {
            SqlCommand comando = GetSqlCommand(procedure);
            List<ViagemCliente> listaViagensClinte = new List<ViagemCliente>();
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                listaViagensClinte.Add(new ViagemCliente(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetBoolean(3),
                    reader.GetInt32(4),
                    reader.GetString(5),
                    reader.GetString(6),
                    reader.GetInt32(7),
                    reader.GetInt32(8),
                    reader.GetString(9),
                    reader.GetString(10)
                ));
            }

            return listaViagensClinte;
        }

        public override ViagemCliente Obter(string nome, string procedure)
        {
            throw new NotImplementedException();
        }

        public List<ViagemCliente> ObterPorId(int id, string procedure)
        {

            SqlCommand comando = GetSqlCommand(procedure);
            List<ViagemCliente> listaViagensClinte = new List<ViagemCliente>();

            comando.Parameters.AddWithValue("@Id", id);

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                listaViagensClinte.Add(new ViagemCliente(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetBoolean(3),
                    reader.GetInt32(4),
                    reader.GetString(5),
                    reader.GetString(6),
                    reader.GetInt32(7),
                    reader.GetInt32(8),
                    reader.GetString(9),
                    reader.GetString(10)
                ));
            }

            return listaViagensClinte;
        }
    }
}
