using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Model
{
    public class ViagensDispo
    {
        public int Id { get; set; }
        public string PlanetaOrigem { get; set; }
        public string PlanetaDestino { get; set; }
        public int Valor { get; set; }
        public int Tempo { get; set; }

        public ViagensDispo(int id, string planetaOrigem, string planetaDestino, int valor, int tempo)
        {
            this.Id = id;
            this.PlanetaOrigem = planetaOrigem;
            this.PlanetaDestino = planetaDestino;
            this.Valor = valor;
            this.Tempo = tempo;
        }

        public ViagensDispo()
        {

        }
    }
}
