using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Model
{
    public class Transportes
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Terreno { get; set; }

        public Transportes(int id, string nome, string terreno)
        {
            this.Id = id;
            this.Nome = nome;
            this.Terreno = terreno;
        }

        public Transportes()
        {

        }
    }
}
