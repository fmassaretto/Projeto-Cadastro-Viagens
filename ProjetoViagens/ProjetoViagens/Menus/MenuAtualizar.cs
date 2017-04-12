using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Menus
{
    class MenuAtualizar : HeaderAbstract
    {
        public static string ShowMenuAtualizar()
        {
            Header();
            Console.WriteLine("Menu 3 - Atualizar");
            Console.WriteLine("******************");
            Console.WriteLine("1 - Atualizar Planeta");
            Console.WriteLine("2 - Atualizar Cliente");
            Console.WriteLine("3 - Atualizar Transporte");
            Console.WriteLine("4 - Atualizar Viagem");
            Console.WriteLine("v - Voltar");
            return Console.ReadLine();
        }
    }
}
