using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Model.DTO
{
    public class ViagemCliente
    {
        public int CodigoReserva { get; set; }
        public int IdCliente { get; set; }
        public int IdViagemDispo { get; set; }
        public int IdTransporte { get; set; }

        public Clientes clientes = new Clientes();

        public ViagensDispo viagemDispo = new ViagensDispo();

        public Transportes transportes = new Transportes();

        public ViagemCliente(int idCliente, string nome, string documento, bool respira, int codigoReserva, string planetaOrigem, string planetaDestino, int valor, int tempo, string nomeTransporte, string terreno)
        {
            clientes.Id = idCliente;
            clientes.Nome = nome;
            clientes.Documento = documento;
            clientes.Respira = respira;
            this.IdCliente = idCliente;
            this.CodigoReserva = codigoReserva;
            viagemDispo.PlanetaOrigem = planetaOrigem;
            viagemDispo.PlanetaDestino = planetaDestino;
            viagemDispo.Valor = valor;
            viagemDispo.Tempo = tempo;
            transportes.Nome = nomeTransporte;
            transportes.Terreno = terreno;

        }

        public ViagemCliente()
        {

        }
    }
}
