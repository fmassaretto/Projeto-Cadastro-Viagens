using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Menus
{
    class MenuConsultarOpcao
    {
        public static string ShowMenuOpcaoConsultar(string elem) {
            Console.WriteLine("Menu 2-1 - Consultar " + elem);
            Console.WriteLine("*****************************************");
            Console.WriteLine("1 - Consultar todos(as) os(as) {0}s", elem);
            Console.WriteLine("2 - Consultar pelo nome do(a) {0}", elem);
            return Console.ReadLine();
        }
    }
}
