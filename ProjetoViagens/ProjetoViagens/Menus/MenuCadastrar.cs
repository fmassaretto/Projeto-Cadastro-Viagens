using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Menus
{
    class MenuCadastrar : HeaderAbstract
    {
        public static string ShowMenuCadastrar()
        {
            Header();
            Console.WriteLine("Menu 1 - Cadastro");
            Console.WriteLine("******************");
            Console.WriteLine("1 - Cadastrar Planeta");
            Console.WriteLine("2 - Cadastrar Cliente");
            Console.WriteLine("3 - Cadastrar Transporte");
            Console.WriteLine("4 - Cadastrar Viagem Disponível");
            Console.WriteLine("v - Voltar");
            return Console.ReadLine();
        }
    }
}
