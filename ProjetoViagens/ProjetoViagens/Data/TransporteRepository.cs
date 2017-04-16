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
    class TransporteRepository : CrudAbstract<Transportes>
    {
        public override Transportes Atualizar(Transportes entidade, string procedure)
        {
            SqlCommand comando = GetSqlCommand(procedure);
            
            comando.Parameters.AddWithValue("@Id", entidade.Id);
            comando.Parameters.AddWithValue("@Nome", entidade.Nome);
            comando.Parameters.AddWithValue("@Terreno", entidade.Terreno);

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

        public override Transportes Incluir(Transportes entidade, string procedure)
        {
            SqlCommand comando = GetSqlCommand(procedure);
           
            comando.Parameters.AddWithValue("@Nome", entidade.Nome);
            comando.Parameters.AddWithValue("@Terreno", entidade.Terreno);

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

        public override List<Transportes> Listar(string procedure)
        {
            SqlCommand comando = GetSqlCommand(procedure);
            SqlDataReader reader = comando.ExecuteReader();

            List<Transportes> listaTransportes = new List<Transportes>();

            while (reader.Read())
            {
                listaTransportes.Add(new Transportes(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2)
                ));
            }

            return listaTransportes;
        }

        public override Transportes Obter(string nome, string procedure)
        {
            SqlCommand comando = GetSqlCommand(procedure);
            comando.Parameters.AddWithValue("@Nome", nome);
            SqlDataReader reader = comando.ExecuteReader();

            Transportes transporte = new Transportes();

            while (reader.Read())
            {
                transporte.Id = reader.GetInt32(0);
                transporte.Nome = reader.GetString(1);
                transporte.Terreno = reader.GetString(2);
            }

            return transporte;
        }
    }
}
