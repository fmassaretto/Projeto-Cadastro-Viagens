using ProjetoViagens.DB.Base;
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
            string opcaoMenuCad = "";
            string opcaoMenuCons = "";

            do
            {
                Menu();
                opcaoMenu = Console.ReadLine();
                if (opcaoMenu == "1")
                {
                    MenuCadastro();
                    opcaoMenuCad = Console.ReadLine();
                    if (opcaoMenuCad == "1")
                    {

                    }
                }
                else if (opcaoMenu == "2")
                {
                    MenuConsulta();
                    opcaoMenuCons = Console.ReadLine();
                    if (opcaoMenuCons == "1")
                    {
                        string Conn = ConfigurationManager.ConnectionStrings["ViagensInterplanetariasDB"].ConnectionString;
                        SqlConnection DBConn = new SqlConnection(Conn);
                        DBConn.Open();
                        SqlCommand command = new SqlCommand("SELECT * FROM Planetas", DBConn);
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Console.WriteLine("{0} - Nome: {1} \nDescrição: {2} \nTem Oxigenio: {3}", reader.GetSqlInt32(0), 
                                reader.GetSqlString(1), reader.GetSqlString(2), reader.GetSqlBoolean(3) == true ? "Sim" : "Não");
                            Console.WriteLine("");
                        }
                        Console.ReadKey();
                    }
                }
            } while (opcaoMenu.ToLower() != "x");



        }

        private static void MenuConsulta()
        {
            Header();
            Console.WriteLine("Menu 2 - Consulta");
            Console.WriteLine("******************");
            Console.WriteLine("1 - Consultar Planeta");
            Console.WriteLine("2 - Consultar Cliente");
            Console.WriteLine("3 - Consultar Transporte");
            Console.WriteLine("4 - Consultar Viagem");
            Console.WriteLine("v - Voltar");
        }

        private static void MenuCadastro()
        {
            Header();
            Console.WriteLine("Menu 1 - Cadastro");
            Console.WriteLine("******************");
            Console.WriteLine("1 - Cadastrar Planeta");
            Console.WriteLine("2 - Cadastrar Cliente");
            Console.WriteLine("3 - Cadastrar Transporte");
            Console.WriteLine("4 - Cadastrar Viagem");
            Console.WriteLine("v - Voltar");
        }

        private static void Header()
        {
            Console.Clear();
            Console.WriteLine("Bem vindo ao Sistema de Viagens Interplanetárias!");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("");
        }

        private static void Menu()
        {
            Header();
            Console.WriteLine("Menu");
            Console.WriteLine("******************");
            Console.WriteLine("1 - Cadastro");
            Console.WriteLine("2 - Consulta");
            Console.WriteLine("x - Encerrar");
        }
    }
}
