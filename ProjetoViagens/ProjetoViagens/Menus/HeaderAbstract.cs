using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Menus
{
    abstract class HeaderAbstract
    {
        public static void Header()
        {
            Console.Clear();
            Console.WriteLine("Bem vindo ao Sistema de Viagens Interplanetárias!");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("");
        }
        
    }
}
