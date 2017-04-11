using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Model.DTO
{
    class ViagemCliente : ViagensDispo
    {
        public int IdCliente { get; set; }
        public int IdViagemDispo { get; set; }
    }
}
