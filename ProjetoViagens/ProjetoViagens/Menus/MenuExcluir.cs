using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Menus
{
    class MenuExcluir : HeaderAbstract
    {
        public static string ShowMenuExcluir()
        {
            Header();
            Console.WriteLine("Menu 4 - Excluir");
            Console.WriteLine("******************");
            Console.WriteLine("1 - Excluir Planeta");
            Console.WriteLine("2 - Excluir Cliente");
            Console.WriteLine("3 - Excluir Transporte");
            Console.WriteLine("4 - Excluir Viagem");
            Console.WriteLine("v - Voltar");
            return Console.ReadLine();
        }
    }
}
