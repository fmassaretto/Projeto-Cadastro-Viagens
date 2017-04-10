using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Model
{
    class Viagens
    {
        public int Id { get; set; }
        public int IdPlanetaOrigem { get; set; }
        public int IdPlanetaDestino { get; set; }
        public int IdCliente { get; set; }
        public float Valor { get; set; }
        public float Tempo { get; set; }
    }
}
