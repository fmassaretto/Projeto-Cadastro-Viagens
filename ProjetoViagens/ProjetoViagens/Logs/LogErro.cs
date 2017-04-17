using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Logs
{
    public class LogErro
    {
        public static void ExecuteLogErro(string streamMsg)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

            string rootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string directoryLogsPath = rootPath + @"\Logs\Erro";

            string fileName = "Erro_" + date + ".txt";
            string fullFilePath = Path.Combine(directoryLogsPath, fileName);

            string logMsg = date + " - " + streamMsg;

            try
            {
                if (!Directory.Exists(directoryLogsPath))
                    Directory.CreateDirectory(directoryLogsPath);

                File.AppendAllText(fullFilePath, logMsg);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao criar log. Mensagem: " + ex.Message);
            }
        }
    }
}
