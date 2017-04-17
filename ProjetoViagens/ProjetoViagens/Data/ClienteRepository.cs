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
    class ClienteRepository : CrudAbstract<Clientes>
    {
        public override Clientes Atualizar(Clientes entidade, string procedure)
        {
            SqlCommand comando = GetSqlCommand(procedure);

            comando.Parameters.AddWithValue("@Id", entidade.Id);
            comando.Parameters.AddWithValue("@Nome", entidade.Nome);
            comando.Parameters.AddWithValue("@Especie", entidade.Especie);
            comando.Parameters.AddWithValue("@Documento", entidade.Documento);
            comando.Parameters.AddWithValue("@Cor", entidade.Cor);
            comando.Parameters.AddWithValue("@QtdBracos", entidade.QtdBracos);
            comando.Parameters.AddWithValue("@QtdPernas", entidade.QtdPernas);
            comando.Parameters.AddWithValue("@QtdCabeca", entidade.QtdCabecas);
            comando.Parameters.AddWithValue("@Respira", entidade.Respira);

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
            SqlCommand comando = GetSqlCommand(procedure);

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

        public override Clientes Incluir(Clientes entidade, string procedure)
        {
            SqlCommand comando = GetSqlCommand(procedure);

            comando.Parameters.AddWithValue("@Nome", entidade.Nome);
            comando.Parameters.AddWithValue("@Especie", entidade.Especie);
            comando.Parameters.AddWithValue("@Documento", entidade.Documento);
            comando.Parameters.AddWithValue("@Cor", entidade.Cor);
            comando.Parameters.AddWithValue("@QtdBracos", entidade.QtdBracos);
            comando.Parameters.AddWithValue("@QtdPernas", entidade.QtdPernas);
            comando.Parameters.AddWithValue("@QtdCabeca", entidade.QtdCabecas);
            comando.Parameters.AddWithValue("@Respira", entidade.Respira);

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
        public override List<Clientes> Listar(string procedure)
        {
            List<Clientes> listaClientes = new List<Clientes>();

            SqlCommand comando = GetSqlCommand(procedure);

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                listaClientes.Add(new Clientes(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetInt32(5),
                    reader.GetInt32(6),
                    reader.GetInt32(7),
                    reader.GetBoolean(8)
                ));
            }

            return listaClientes;
        }

        public override Clientes Obter(string nome, string procedure)
        {
            SqlCommand comando = GetSqlCommand(procedure);

            comando.Parameters.AddWithValue("@Nome", nome);
            SqlDataReader reader = comando.ExecuteReader();

            Clientes cliente = new Clientes();
            while (reader.Read())
            {
                cliente.Id = reader.GetInt32(0);
                cliente.Nome = reader.GetString(1);
                cliente.Especie = reader.GetString(2);
                cliente.Documento = reader.GetString(3);
                cliente.Cor = reader.GetString(4);
                cliente.QtdBracos = reader.GetInt32(5);
                cliente.QtdPernas = reader.GetInt32(6);
                cliente.QtdCabecas = reader.GetInt32(7);
                cliente.Respira = reader.GetBoolean(8);
            }           

            return cliente;
        }

        public Clientes ObterPorId(int id, string procedure)
        {
            SqlCommand comando = GetSqlCommand(procedure);

            comando.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = comando.ExecuteReader();

            Clientes cliente = new Clientes();
            while (reader.Read())
            {
                cliente.Id = reader.GetInt32(0);
                cliente.Nome = reader.GetString(1);
                cliente.Especie = reader.GetString(2);
                cliente.Documento = reader.GetString(3);
                cliente.Cor = reader.GetString(4);
                cliente.QtdBracos = reader.GetInt32(5);
                cliente.QtdPernas = reader.GetInt32(6);
                cliente.QtdCabecas = reader.GetInt32(7);
                cliente.Respira = reader.GetBoolean(8);
            }

            return cliente;
        }
    }
}
