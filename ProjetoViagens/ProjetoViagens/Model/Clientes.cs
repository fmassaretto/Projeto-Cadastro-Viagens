using ProjetoViagens.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Model
{
    public class Clientes : IEspecies
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Especie { get; set; }
        public string Cor { get; set; }

        public int QtdBracos { get; set; }

        public int QtdPernas { get; set; }

        public int QtdCabecas { get; set; }

        public bool Respira { get; set; }

        public Clientes(int id, string nome, string especie, string doc, string cor, int qtdBracos, int qtdPernas, int qtdCabecas, bool respira)
        {
            this.Id = id;
            this.Nome = nome;
            this.Especie = especie;
            this.Documento = doc;
            this.Cor = cor;
            this.QtdBracos = qtdBracos;
            this.QtdPernas = qtdPernas;
            this.QtdCabecas = qtdCabecas;
            this.Respira = respira;
        }
        public Clientes()
        {

        }
    }
}
