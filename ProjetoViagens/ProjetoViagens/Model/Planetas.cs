using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Model
{
    class Planetas
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool PossuiOxigenio { get; set; }

        public override string ToString()
        {
            var retorno = string.Empty;
            retorno += "#Id: " + this.Id.ToString();
            retorno += "#Nome: " + this.Nome;
            retorno += "#Descrição: " + this.Descricao;
            retorno += "#Oxigenio: " + (this.PossuiOxigenio == true ? "Sim" : "Não");

            return retorno;
        }

        public Planetas(int id, string nome, string descr, bool possuiOx)
        {
            this.Id = id;
            this.Nome = nome;
            this.Descricao = descr;
            this.PossuiOxigenio = possuiOx;
        }
        public Planetas()
        {

        }
    }
}
