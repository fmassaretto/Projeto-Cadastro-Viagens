using ProjetoViagens.Data;
using ProjetoViagens.DB.Base;
using ProjetoViagens.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcaoMenu = "";

            do
            {
                opcaoMenu = Menu();
                if (opcaoMenu == "1")
                {
                    if (MenuCadastro() == "1")
                    {
                        CadastarPlaneta();
                    }
                }
                else if (opcaoMenu == "2")
                {
                    string opcaoMenuConsulta = MenuConsulta();
                    if (opcaoMenuConsulta == "1")
                    {
                        MenuConsultaOpcao<Planetas>("Planeta", "planetasTodos_sps", "planetasPorNome_sps");
                    }
                    else if (opcaoMenuConsulta == "2")
                    {
                        MenuConsultaOpcao<Especies>("Cliente", "ClientesTodos_sps", "clientesPorNome_sps");
                    }
                    else if (opcaoMenuConsulta == "3")
                    {

                    }
                    else if (opcaoMenuConsulta == "4")
                    {

                    }
                }
            } while (opcaoMenu.ToLower() != "x");

        }

        private static void MenuConsultaOpcao<T>(string nomeConsulta, string proc1, string proc2)
        {
           string opcaoConsultar = HeaderOpcaoConsultar(nomeConsulta);
            if (opcaoConsultar == "1")
            {
                MostrarConsulta<T>(nomeConsulta, proc1, null);
            }
            else if (opcaoConsultar == "2")
            {               
                Console.WriteLine("Qual o nome do(a) {0}?", nomeConsulta);
                string nome = Console.ReadLine();

                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@Nome", nome));

                MostrarConsulta<T>(nomeConsulta, proc2, parametros);
            }
        }

        private static void MostrarConsulta<T>(string nomeConsulta, string procedure, List<SqlParameter> parametros)
        {
            Repository<T> repo = new Repository<T>();
            SqlDataReader reader = null;

            if (parametros != null)
            {
                reader = repo.ExecuteProc(procedure, parametros);
            }
            else
            {
                reader = repo.ExecuteProc(procedure);
            }
            

            while (reader.Read())
            {
                if (nomeConsulta == "Planeta")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Nome: {0} | Descrição: {1} \nTem Oxigenio: {2}", reader.GetSqlString(0), reader.GetSqlString(1),
                        reader.GetSqlBoolean(2) == true ? "Sim" : "Não");
                }
                else if (nomeConsulta == "Cliente")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Id: {0} - Nome: {1} | Documento: {2} | Cor: {3} | Qtde Braços: {4} | " +
                        "Qtde Pernas: {5} | Qtde Cabeças: {6} | Respira? {7}", reader.GetSqlInt32(0), reader.GetSqlString(1), 
                        reader.GetSqlString(2), reader.GetSqlString(3), reader.GetSqlInt32(4), reader.GetSqlInt32(5), reader.GetSqlInt32(6),
                        reader.GetSqlBoolean(7) == true ? "Sim" : "Não");
                }
                
            }

            Console.ReadKey();
        }

        private static string HeaderOpcaoConsultar(string elem)
        {
            Console.WriteLine("Menu 2-1 - Consultar " + elem);
            Console.WriteLine("*****************************************");
            Console.WriteLine("1 - Consultar todos(as) os(as) {0}s", elem);
            Console.WriteLine("2 - Consultar pelo nome do(a) {0}", elem);
            return Console.ReadLine();
        }

        private static void CadastarPlaneta()
        {
            Console.WriteLine("Menu 1-1 - Cadastrar Planeta");
            Console.WriteLine("******************");
            Console.WriteLine("");

            Console.WriteLine("Digite o nome do planeta?");
            string nomePlaneta = Console.ReadLine();

            Console.WriteLine("Escreva a descrição do planeta?");
            string descPlaneta = Console.ReadLine();

            Console.WriteLine("Esse planeta possui oxigenio? (s/n)");
            string possuiOxigenio = Console.ReadLine();

            bool convPossuiOxigenio = possuiOxigenio.ToLower() == "s" ? true : false;

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Nome", nomePlaneta));
            parametros.Add(new SqlParameter("@Descricao", descPlaneta));
            parametros.Add(new SqlParameter("@PossuiOxigenio", convPossuiOxigenio));
            MostrarInserir<Planetas>("planetas_spi", parametros);
        }

        private static void MostrarInserir<T>(string procedure, List<SqlParameter> parametros)
        {
            Repository<T> repo = new Repository<T>();
            SqlDataReader reader = repo.ExecuteProc(procedure, parametros);

            Console.WriteLine("******************");
            while (reader.Read())
            {
                Console.WriteLine(reader.GetValue(0));
            }

            Console.ReadKey();
        }

        private static string MenuConsulta()
        {
            Header();
            Console.WriteLine("Menu 2 - Consulta");
            Console.WriteLine("******************");
            Console.WriteLine("1 - Consultar Planeta");
            Console.WriteLine("2 - Consultar Cliente");
            Console.WriteLine("3 - Consultar Transporte");
            Console.WriteLine("4 - Consultar Viagem");
            Console.WriteLine("v - Voltar");
            return Console.ReadLine();
        }

        private static string MenuCadastro()
        {
            Header();
            Console.WriteLine("Menu 1 - Cadastro");
            Console.WriteLine("******************");
            Console.WriteLine("1 - Cadastrar Planeta");
            Console.WriteLine("2 - Cadastrar Cliente");
            Console.WriteLine("3 - Cadastrar Transporte");
            Console.WriteLine("4 - Cadastrar Viagem");
            Console.WriteLine("v - Voltar");
            return Console.ReadLine();
        }

        private static void Header()
        {
            Console.Clear();
            Console.WriteLine("Bem vindo ao Sistema de Viagens Interplanetárias!");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("");
        }

        private static string Menu()
        {
            Header();
            Console.WriteLine("Menu");
            Console.WriteLine("******************");
            Console.WriteLine("1 - Cadastro");
            Console.WriteLine("2 - Consulta");
            Console.WriteLine("x - Encerrar");
            return Console.ReadLine();
        }
    }
}
