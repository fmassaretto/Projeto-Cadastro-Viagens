using ProjetoViagens.Data.Base;
using ProjetoViagens.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens.Data
{
    class BookingRepository : CrudAbstract<ViagemCliente>
    {
        public override ViagemCliente Atualizar(ViagemCliente entidade, string procedure)
        {
            throw new NotImplementedException();
        }

        public override void Excluir(int Id, string procedure)
        {
            throw new NotImplementedException();
        }

        public override ViagemCliente Incluir(ViagemCliente entidade, string procedure)
        {
            throw new NotImplementedException();
        }

        public override List<ViagemCliente> Listar(string procedure)
        {
            throw new NotImplementedException();
        }

        public override ViagemCliente Obter(string nome, string procedure)
        {
            throw new NotImplementedException();
        }
    }
}
