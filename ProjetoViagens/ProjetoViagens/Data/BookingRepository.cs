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
            throw new NotImplementedException();
        }

        public override void Excluir(int Id, string procedure)
        {
            throw new NotImplementedException();
        }

        public override ViagemCliente Incluir(ViagemCliente entidade, string procedure)
        {

            SqlCommand comando = base.GetSqlCommand(procedure);

            comando.Parameters.AddWithValue("@IdViagemDispo", entidade.IdViagemDispo);
            comando.Parameters.AddWithValue("@IdCliente", entidade.IdCliente);

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

        public override List<ViagemCliente> Listar(string procedure)
        {
            SqlCommand comando = base.GetSqlCommand(procedure);
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
                    reader.GetInt32(8)
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

            SqlCommand comando = base.GetSqlCommand(procedure);
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
                    reader.GetInt32(8)
                ));
            }

            return listaViagensClinte;
        }
    }
}
