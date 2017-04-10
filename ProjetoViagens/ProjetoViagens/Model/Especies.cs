using ProjetoViagens.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Model
{
    class Especies : ICliente
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Cor { get; set; }
        public int QtdBracos { get; set; }
        public int QtdPernas { get; set; }
        public int QtdCabeca { get; set; }
        public bool Respira { get; set; }
    }
}
