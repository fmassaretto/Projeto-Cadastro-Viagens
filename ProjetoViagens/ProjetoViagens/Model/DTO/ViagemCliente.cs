using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Model.DTO
{
    class ViagemCliente : ViagensDispo
    {
        public int CodigoReserva { get; set; }
        public int IdCliente { get; set; }
        public int IdViagemDispo { get; set; }

        public Clientes clientes = new Clientes();

        public ViagemCliente(int idCliente, string nome, string documento, bool respira, int codigoReserva, string planetaOrigem, string planetaDestino, int valor, int tempo)
        {
            //clientes.Id = idCliente;
            clientes.Nome = nome;
            clientes.Documento = documento;
            clientes.Respira = respira;
            this.IdCliente = idCliente;
            this.Id = codigoReserva;
            base.PlanetaOrigem = planetaOrigem;
            base.PlanetaDestino = planetaDestino;
            base.Valor = valor;
            base.Tempo = tempo;


        }

        public ViagemCliente()
        {

        }
    }
}
