using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Menus
{
    class MenuConsultar : HeaderAbstract
    {
        public static string ShowMenuConsultar()
        {
            Header();
            Console.WriteLine("Menu 2 - Consultar");
            Console.WriteLine("******************");
            Console.WriteLine("1 - Consultar Planeta");
            Console.WriteLine("2 - Consultar Cliente");
            Console.WriteLine("3 - Consultar Transporte");
            Console.WriteLine("4 - Consultar Viagens Disponiveis");
            Console.WriteLine("v - Voltar");
            return Console.ReadLine();
        }
    }
}
