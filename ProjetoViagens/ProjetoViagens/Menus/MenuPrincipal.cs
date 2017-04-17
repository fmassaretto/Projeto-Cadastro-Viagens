using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Menus
{
    class MenuPrincipal : HeaderAbstract
    {
        public static string ShowMenuPrincipal()
        {
            Header();
            Console.WriteLine("Menu");
            Console.WriteLine("******************");
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Consultar");
            Console.WriteLine("3 - Atualizar");
            Console.WriteLine("4 - Excluir");
            Console.WriteLine("******************");
            Console.WriteLine("5 - Fazer Booking da Viagem");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("6 - Exibir o log de erros");
            Console.WriteLine("");
            Console.WriteLine("x - Encerrar");
            return Console.ReadLine();
        }
    }
}