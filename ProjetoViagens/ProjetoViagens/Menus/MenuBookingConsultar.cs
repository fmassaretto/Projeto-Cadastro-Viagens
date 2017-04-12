using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Menus
{
    class MenuBookingConsultar
    {
        public static string ShowMenuConsultarooking()
        {
            Console.WriteLine("O que deseja fazer:");
            Console.WriteLine("1 - Consultar todos os booking dos clientes");
            Console.WriteLine("2 - Consultar booking por ID do cliente");

            return Console.ReadLine();
        }
    }
}
