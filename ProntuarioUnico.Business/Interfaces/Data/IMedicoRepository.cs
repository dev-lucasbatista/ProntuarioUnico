using ProntuarioUnico.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioUnico.Business.Interfaces.Data
{
    public interface IMedicoRepository
    {
        Medico Obter(Int32 codigo);

        Medico Obter(String crm);

        Medico Alterar(Medico medicoAlterado);

        Boolean CRMExistente(string crm);
    }
}
