using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Model.Interface
{
    interface IEspecies
    {
        int Id { get; set; }
        string Especie { get; set; }
        string Documento { get; set; }
        string Cor { get; set; }
        int QtdBracos { get; set; }
        int QtdPernas { get; set; }
        int QtdCabecas { get; set; }
        bool Respira { get; set; }
    }
}
