using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Model.Interface
{
    interface ICliente
    {
        int Id { get; set; }
        string Nome { get; set; }
        string Documento { get; set; }
    }
}
