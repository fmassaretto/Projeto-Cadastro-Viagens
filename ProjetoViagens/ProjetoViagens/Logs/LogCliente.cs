using ProjetoViagens.Model.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Logs
{
    public class LogCliente
    {
        public static void ExecuteLogCliente(ViagemCliente viagemCliente)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

            string rootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string directoryLogsPath = rootPath + @"\Logs\Clientes";

            string clienteNomeId = viagemCliente.clientes.Nome + "_" + viagemCliente.clientes.Id.ToString();
            string clientDirectory = Path.Combine(directoryLogsPath, clienteNomeId);

            string fileName = "Ticket_" + viagemCliente.CodigoReserva + "_" + date + ".txt";
            string fullFilePath = Path.Combine(clientDirectory, fileName);

            string logMsg = date + " - Cliente: " + viagemCliente.clientes.Nome + " comprou passagem De: " + viagemCliente.viagemDispo.PlanetaOrigem +
                " - Para: " + viagemCliente.viagemDispo.PlanetaDestino + ",\n no valor de: " + 
                viagemCliente.viagemDispo.Valor + ", distancia de: " + viagemCliente.viagemDispo.Tempo + " Anos-Luz - Meio de Transporte: " + viagemCliente.transportes.Nome;

            try
            {
                if (!Directory.Exists(directoryLogsPath))
                    Directory.CreateDirectory(directoryLogsPath);

                if (!Directory.Exists(clientDirectory))
                    Directory.CreateDirectory(clientDirectory);

                File.AppendAllText(fullFilePath, logMsg);
            }
            catch (Exception ex)
            {
                LogErro.ExecuteLogErro("Erro ao criar log de tickets do cliente ID: " + viagemCliente.IdCliente.ToString() +
                    ". StackTrace: " + ex.StackTrace + " Mensagem de erro: " + ex.Message);
                Console.WriteLine("Erro ao criar log do cliente, consulte o log de erro para mais detalhes.");
            }                       
        }
    }
}
