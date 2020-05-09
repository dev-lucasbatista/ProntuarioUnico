using ProntuarioUnico.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioUnico.Business.Interfaces.Data
{
    public interface IAtendimentoRepository
    {
        Atendimento Cadastrar(Atendimento novoAtendimento);

        Atendimento Alterar(Atendimento atendimentoAlterado);

        Atendimento AlterarToken(Atendimento atendimentoAlterado);

        Atendimento Obter(Int32 numeroAtendimento);
    }
}
