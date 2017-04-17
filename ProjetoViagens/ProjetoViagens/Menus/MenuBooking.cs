using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Menus
{
    class MenuBooking : HeaderAbstract
    {
        public static string ShowMenuBooking()
        {
            Header();
            Console.WriteLine("Menu 5 - Booking da Viagem");
            Console.WriteLine("******************");
            Console.WriteLine("1 - Fazer Booking");
            Console.WriteLine("2 - Consultar Booking");
            Console.WriteLine("3 - Consultar Tickets");
            Console.WriteLine("4 - Atualizar Booking");
            Console.WriteLine("5 - Excluir Booking");
            Console.WriteLine("v - Voltar");
            return Console.ReadLine();
        }
    }
}
