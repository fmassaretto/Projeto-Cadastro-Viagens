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
            throw new NotImplementedException();
        }

        public override void Excluir(int Id, string procedure)
        {
            throw new NotImplementedException();
        }

        public override ViagensDispo Incluir(ViagensDispo entidade, string procedure)
        {
            throw new NotImplementedException();
        }

        public override List<ViagensDispo> Listar(string procedure)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = procedure;

            List<ViagensDispo> listaViagens = new List<ViagensDispo>();

            comando.Connection = base.GetConnection();
            comando.Connection.Open();
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
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = procedure;

            List<ViagensDispo> listaViagens = new List<ViagensDispo>();

            comando.Connection = base.GetConnection();
            comando.Connection.Open();

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
