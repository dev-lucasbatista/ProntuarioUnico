using ProntuarioUnico.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioUnico.Business.Interfaces.Data
{
    public interface ITipoAtendimentoRepository
    {
        List<TipoAtendimento> ListarAtivos();

        TipoAtendimento Obter(int codigo);
    }
}
